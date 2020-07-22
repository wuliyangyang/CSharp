
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;
using System.Threading;

namespace MyZMQ.ZMQSocket
{
    public class Publisher
    {
        private string address;
        private ZContext context;
        private ZSocket socket;
        private Thread workThread;

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public int PubTimes { get; set; }

        public int PubMode { get; set; }

        public bool IsKeepRun { get; set; }

        public bool IsDataReady { get; set; }

        public string Name { get; set; }

        public string StringToBePub { get; set; }

        public event PostMsgHandler LogInfo_Evt;
        public event PostMsgHandler LogError_Evt;
        public Publisher()
        {
            Init();
        }


        public void LogInfo(string msg)
        {
            if (LogInfo_Evt != null)
            {
                LogInfo_Evt.Invoke(this, msg);
            }
        }
        public void LogError(string msg)
        {
            if (LogError_Evt != null)
            {
                LogError_Evt.Invoke(this, msg);
            }
        }
        public void InitZMQ()
        {
            try
            {
                if (null == context)
                {
                    if (null == Global.UniqueZContext)
                    {
                        Global.UniqueZContext = ZContext.Create();
                    }
                    context = Global.UniqueZContext;
                }
                if (null == socket)
                {
                    socket = new ZSocket(context, ZSocketType.PUB);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("[Exception]->>" + ee.Message);
            }
        }

        private int SendMsg(string msg)
        {
            try
            {
                using (ZFrame ZF = new ZFrame(msg))
                {
                    ZError error;
                    bool isSendOk = socket.Send(ZF, ZSocketFlags.DontWait, out error);
                    if (!isSendOk)
                    {
                        LogError(msg + " fail!!!" + " error:" + error.ToString() + "\r\n");
                        return -1;
                    }
                    else
                    {
                        LogInfo(msg + "\r\n");
                    }
                }
            }
            catch (Exception e)
            {
                LogError("[EXCEPTION]->>SendMsg Exception:" + e.Message);
                return -2;
            }
            return 0;
        }


        private void InitThread()
        {
            workThread = new Thread(OnThreadRun);
            workThread.IsBackground = true;
            workThread.Start();
        }
        private void OnThreadRun()
        {
            try
            {
                SendMsg("hello guys!!");
                Thread.Sleep(1500);
                while (IsKeepRun)
                {
                    Thread.Sleep(10);
                    if (IsDataReady)
                    {
                        SendMsg(StringToBePub);
                        //IsDataReady = false;
                        Thread.Sleep(20);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void StopWorkThread()
        {
            if (workThread.IsAlive)
            {
                workThread.Abort();
            }
        }

        public bool StartServer(string address)
        {
            return Bind(address);
        }
        public bool StopServer(string address)
        {
            return UnBind(address);
        }
        private bool Bind(string address)
        {
            Address = address;
            InitZMQ();
            ZError error;
            bool isBindOk = socket.Bind(this.address, out error);
            if (error != null) LogInfo(error.ToString());
            LogInfo("Bind " + Address + " " + isBindOk + "\r\n");
            return isBindOk;
        }
        private bool UnBind(string address)
        {
            ZError error;
            bool isBindOk = socket.Unbind(this.address, out error);
            if (error != null) LogInfo(error.ToString());
            LogInfo("UnBind " + Address + " " + isBindOk + "\r\n");
            return isBindOk;
        }

        public void StartPub()
        {
            InitThread();
        }

        public void StopPub()
        {
            IsDataReady = false;
            StopWorkThread();
        }
        private void Init()
        {
            IsDataReady = false;
            IsKeepRun = true;
            StringToBePub = "";

        }
    }
}
