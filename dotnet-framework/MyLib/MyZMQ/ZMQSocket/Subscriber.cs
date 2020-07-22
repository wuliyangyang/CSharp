using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeroMQ;
using System.Threading;

namespace MyZMQ.ZMQSocket
{
    class Subscribe
    {
        public Subscribe()
        {
            Init();
        }

        public event PostMsgHandler LogInfo_Evt;
        public event PostMsgHandler LogError_Evt;
        public event PostMsgHandler RecvMsg_Evt;

        private ZContext context;
        private ZSocket myZSocket;
        Thread workThread;
        public bool IsThreadRunning { get; set; }

        [DescriptionAttribute("The name of Subscriber.")]
        public string Name { get; set; }

        [DescriptionAttribute("The address of Subscriber.")]
        public string Address { get; set; }

        [DescriptionAttribute("The message Filter(etc.'101') of Subscriber.")]
        public string MsgFilter { get; set; }

        [DescriptionAttribute("The Message frames' Separator(etc.'!@#') from target publisher.")]
        public string MsgFrameSeprator { get; set; }

        [DescriptionAttribute("The flag determine whether the worker thread will keep running.")]
        public bool IsEnableRun { get; private set; }


        private void Init()
        {
            this.MsgFilter = "";//Set default filter.
            this.MsgFrameSeprator = "";//Set default msg separator.
            this.Address = "tcp://127.0.0.1:8899";
            this.Name = "Subscriber";//
            this.IsEnableRun = true;//

        }
        protected virtual void CallLogInfoEventHandler(string msg)
        {
            try
            {
                if (null != LogInfo_Evt) LogInfo_Evt.Invoke(this, msg);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("CallLogInfoEventHandler exception: " + ex.Message);
            }
        }


        protected virtual void CallLogErrorEventHandler(string msg)
        {
            try
            {
                if (null != LogError_Evt)
                {
                    LogError_Evt.Invoke(this, msg);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("CallLogErrorEventHandler exception: " + ex.Message);
            }
        }
        protected virtual string AppendMsgAttribute(string msg)
        {
            string msgStr = " [Subscriber(" + Address + ")] " + msg;
            return msgStr;
        }
        protected virtual void LogInfo(string msg)
        {
            string msgStr = AppendMsgAttribute(msg);
            CallLogInfoEventHandler(msgStr);
        }


        protected virtual void LogError(string msg)
        {
            string msgStr = AppendMsgAttribute(msg);
            CallLogErrorEventHandler(msgStr);
        }
        protected virtual void OnMsgReceived(string msg)
        {
            string newMsgStr = msg;
            try
            {
                if (null != RecvMsg_Evt)
                {
                    RecvMsg_Evt.Invoke(this, newMsgStr);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("OnMsgReceived exception: " + ex.Message);
            }
        }
        /// <summary>
        /// Worker Thread Circle Run Method.
        /// </summary>
        /// <param name="sender"></param>
        protected virtual void OnThreadRun(object sender)
        {
            LogInfo("WorkerThread is now running!");
            ZError error;
            try
            {
                //1. Create ZMQ Context;
                if (null == context)
                {
                  
                    if (null == Global.UniqueZContext)
                    {
                        Global.UniqueZContext = ZContext.Create();
                    }
                    context = Global.UniqueZContext;
                    LogInfo("ZMQ Context Init OK!");
                }
                //2. Create ZMQ Socket;
                if (null == myZSocket)
                {
                    myZSocket = new ZSocket(context, ZSocketType.SUB);
                    if (null == myZSocket) { LogError("Init ZMQ Socket Fail!!!"); return; }
                    LogInfo("ZMQ Socket Init OK!");
                }
                //3. Set ZMQ msg filter;
                bool rst = myZSocket.SetOption(ZSocketOption.SUBSCRIBE, MsgFilter);
                if (false == rst)
                {
                    LogError("ZMQ Socket SetOption Fail!\r\n");
                    return;
                }
                LogInfo("ZMQ Socket SetOption OK!");
                //4. Build connection to target.
                bool isOk = myZSocket.Connect(Address, out error);
                if (null != error)
                {
                    LogError("ZMQ Socket Connect to target '" + Address + "' Failed!!! \r\n");
                    return;
                }
                LogInfo("ZMQ Socket build connection to " + Address + " successfully!\r\n");

                IsEnableRun = true;
                List<ZFrame> frameList = new List<ZFrame>();
                StringBuilder sbMessageStrings = new StringBuilder();
                ZError zError = new ZError(1);
                //5. Start thread circle running.
                while (IsEnableRun)
                {
                    IsThreadRunning = true;
                    Thread.Sleep(10);
                    //1. Try to get new msg frame;

                    using (ZFrame newMsgFrame = myZSocket.ReceiveFrame(ZSocketFlags.DontWait, out zError))
                    {
                        if (newMsgFrame != null)
                        {
                            frameList.Clear();
                            frameList.Add(newMsgFrame);

                            /******/
                            sbMessageStrings.Clear();
                            sbMessageStrings.Append(newMsgFrame.ReadString() + MsgFrameSeprator);
                            newMsgFrame.Dispose();//Important!!! Memory leak if no this code.

                            OnMsgReceived(sbMessageStrings.ToString());



                        }//if (reply != null)
                    }//using (ZFrame reply = myZSocket.ReceiveFrame())
                }//while (IsKeepRun)
            }
            catch (Exception e)
            {
                IsEnableRun = false;
                IsThreadRunning = false;
                LogError("OnThreadRun Exception Happened: " + e.Message.ToString());
            }
            finally
            {
                IsEnableRun = false;
                IsThreadRunning = false;
                LogError("WorkerThread over and Call stopped!");
                if (null != myZSocket)
                {
                    myZSocket.Disconnect(Address);
                }
            }
        }
        protected virtual int InitWorkerThread()
        {
            workThread = new Thread(OnThreadRun);
            workThread.IsBackground = true;
            workThread.Start();
            return 0;
        }

        protected virtual int StopWorkThread()
        {
            if (workThread.IsAlive)
            {
                workThread.Abort();
                return 0;
            }
            return -1;

        }
        public virtual int Start()
        {
            if (IsThreadRunning) return -1;
            return InitWorkerThread();
        }
        public virtual int Stop()
        {
            return StopWorkThread();
        }
    }


}
