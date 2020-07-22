using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ZeroMQ;
using System.Windows.Forms;

namespace MyZMQ
{
    class Replier : BaseSocket
    {
        public Replier()
        {
            Init();
            InitZMQ();
        }

        public event PostMsgHandler LogInfo_Evt;
        public event PostMsgHandler LogError_Evt;
        public event PostMsgHandler OnMessage_Evt;


        private Thread workThread;
        private ZSocket mySocket;
        private ZContext myContext;
        private bool isKeepRun = true;

        [Browsable(true), DefaultValue(typeof(string), "tcp://127.0.0.1:8899"), Description("Set and Read Sequencer address string include IP and PORT"), Category("CustomProperties")]
        public string Address { get; set; }
        public string RepMsg { get; set; }

        private void Init()
        {
            Address = "tcp://127.0.0.1:8899";
            RepMsg = "";
            Name = "Rep";
        }
        private void InitZMQ()
        {
            if (null == Global.UniqueZContext)
            {
                Global.UniqueZContext = ZContext.Create();
            }
            myContext = Global.UniqueZContext;
            mySocket = new ZSocket(myContext, ZSocketType.REP);
        }

        private int InitWorkThread()
        {
            if (workThread != null && workThread.IsAlive) return -1;
            workThread = new Thread(OnThreadRun);
            workThread.IsBackground = true;
            workThread.Start();
            return 0;
        }
        private int StopWorkThread()
        {
            if (workThread != null && workThread.IsAlive)
            {
                workThread.Abort();
                return 0;
            }
            return -1;
        }

        private void OnThreadRun()
        {

            List<ZFrame> frameList = new List<ZFrame>(); ;
            ZError error;
            StringBuilder str = new StringBuilder();
            LogInfo("Start To Run Replier Server...");

            try
            {
                while (isKeepRun)
                {
                    Thread.Sleep(20);
                    //Application.DoEvents();

                    ZMessage zm = new ZMessage();
                    ZPollItem zp = ZPollItem.CreateReceiver();
                    bool isOk = mySocket.Poll(zp, ZPoll.In, ref zm, out error);
                    if (isOk)
                    {
                        foreach (ZFrame frame in zm)
                        {
                            str.Append(frame.ReadString() /*+ MSG_SEP*/);
                            frame.Dispose();
                        }

                        LogInfo("Recv Msg: " + str + "\r\n");
                        OnSendOrgMsg(str.ToString());
                        OnRepMsg(RepMsg);

                        frameList.RemoveAll(it => true);
                        zm.Dispose();
                        str.Clear();
                    }
                }
            }

            catch (Exception e)
            {
                isKeepRun = false;
                LogError("Replier Server Thread Exception:" + e.Message);
            }
        }

        private void OnSendOrgMsg(string msg)
        {
            if (OnMessage_Evt != null)
            {
                this.OnMessage_Evt(this, msg);
            }
        }
        private bool OnRepMsg(string msg)
        {
            using (ZFrame zf = new ZFrame(msg))
            {
                bool isOK;
                ZError error;

                isOK = mySocket.SendFrame(zf, ZSocketFlags.DontWait, out error);
                if (!isOK)
                {
                    LogError("Send Reply Msg Fail! Error Msg:" + error.ToString() + " Reply Msg: " + msg);
                    return false;
                }
                else
                {
                    LogInfo("Send Reply Msg OK! Reply Msg: " + msg + "\r\n");
                }
            }
            return true;
        }


        private bool Bind(string address)
        {
            if (myContext != null)
            {
                ZError error;
                bool isOK = mySocket.Bind(address, out error);
                if (isOK) LogInfo("Bind to " + address + " OK!");
                else LogInfo("Bind to " + address + " Failed!" + error.Text);
                return isOK;
            }

            LogError("Bind to " + address + "failed!--->ZmqContext is null!");//WriteLog
            return false;
        }
        private bool Unbind(string address)
        {
            if (null == myContext)
            {
                LogError("Disconnect to " + address + "failed!--->ZmqContext is null!");//WriteLog
                return false;
            }
            if (null == mySocket)
            {
                LogError("Disconnect to " + address + "failed!--->ZmqSocket is null!");//WriteLog
                return false;
            }

            ZError error;
            bool isConOK = mySocket.Unbind(address, out error);
            if (isConOK) LogInfo("Disconnect to " + address + " OK!");
            else LogError("Disconnect to " + address + " Failed! " + error.Text);

            return isConOK;
        }

        public bool InitServer(string address)
        {
            Address = address;
            return Bind(address);
        }
        public bool EndServer(string address)
        {
            return Unbind(address);
        }
        public int Start()
        {
            return InitWorkThread();
        }
        public int Stop()
        {
            isKeepRun = false;
            return StopWorkThread();
        }
        private void LogInfo(string msgStr)
        {
            string str = GetAttributeString() + msgStr;
            if (null != LogInfo_Evt)
            {
                LogInfo_Evt.Invoke(this, str);
            }
        }

        private void LogError(string errorStr)
        {
            string str = GetAttributeString() + errorStr;
            if (null != LogError_Evt)
            {
                LogError_Evt.Invoke(this, str);
            }
        }

        private string GetAttributeString()
        {
            return "[Replier(" + Address + ")] ";
        }

    }
}
