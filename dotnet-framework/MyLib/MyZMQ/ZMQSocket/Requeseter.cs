using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;
using System.Threading;

namespace MyZMQ
{
    class Requeseter:BaseSocket
    {
        public Requeseter()
        {
            Init();
            InitZMQ();
        }

        public event PostMsgHandler LogInfo_Evt;
        public event PostMsgHandler LogError_Evt;
        public event RecvMsgHandler OnRecvMessage_Evt;


        private ZSocket mySocket;
        private ZContext myContext;
        private Thread workThread;

        public string Address { get; set; }

        private void Init()
        {
            Name = "Req";
            Address = "tcp://127.0.0.1:8800";
        }
        public virtual void LogInfo(string msg)
        {

            if (LogInfo_Evt != null)
            {
                LogInfo_Evt.Invoke(this, msg);
            }
        }

        /// <summary>
        /// Log Error.
        /// </summary>
        /// <param name="msg"></param>
        public virtual void LogError(string msg)
        {
            if (LogError_Evt != null)
            {
                LogError_Evt.Invoke(this, msg);
            }
        }

        protected virtual void CallReplyMsgHandler(string msg)
        {
            if (OnRecvMessage_Evt != null)
            {
                OnRecvMessage_Evt.Invoke(this, msg);
            }
        }

        private void InitZMQ()
        {
            if (myContext==null)
            {
                myContext = Global.UniqueZContext;
            }

            mySocket = new ZSocket(myContext, ZSocketType.REQ);
        }

        private bool Connect(string address)
        {
            if (myContext != null)
            {
                ZError error;
                bool isOK = mySocket.Connect(address, out error);
                if (isOK) LogInfo("Bind to " + address + " OK!");
                else LogInfo("Bind to " + address + " Failed!" + error.Text);
                return isOK;
            }

            LogError("Bind to " + address + "failed!--->ZmqContext is null!");//WriteLog
            return false;
        }
        private bool Disconnect(string address)
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
            bool isConOK = mySocket.Disconnect(address, out error);
            if (isConOK) LogInfo("Disconnect to " + address + " OK!");
            else LogError("Disconnect to " + address + " Failed! " + error.Text);

            return isConOK;
        }

        private int InitWorkThread()
        {
            if (workThread != null && workThread.IsAlive) return -1;
            workThread = new Thread(OnWaitRepMgs);
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
        public bool InitServer(string address)
        {
            Address = address;
            return Connect(address);
        }
        public bool EndServer(string address)
        {
            return Disconnect(address);
        }
        public int Start()
        {
            return InitWorkThread();
        }
        public int Stop()
        {
            return StopWorkThread();
        }

        private void OnWaitRepMgs()
        {
            try
            {
                ZError error;
                string rcvdMsg;
                while (true)
                {
                    ZMessage zm = new ZMessage();
                    ZPollItem zp = ZPollItem.CreateReceiver();
                    bool isOk = mySocket.Poll(zp, ZPoll.In, ref zm, out error);
                    if (isOk)
                    {
                        StringBuilder str = new StringBuilder();
                        foreach (ZFrame frame in zm)
                        {
                            str.Append(frame.ReadString() /*+ MSG_SEP*/);
                            frame.Dispose();
                        }
                        rcvdMsg = str.ToString();
                        LogInfo("The Entire Reply Msg: \r\n" + str.ToString());
                        CallReplyMsgHandler(rcvdMsg);

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public int RequestMsg(string sendMsg)
        {
            using (var msgFrame = new ZFrame(sendMsg))
            {
                ZError error;
                bool isSndOK = mySocket.Send(msgFrame, ZSocketFlags.DontWait, out error);
                if (!isSndOK)
                {
                    //Console.WriteLine("---[Request]---Send Msg Fail! " + error.ToString());
                    LogError("Send Msg Fail! " + error.ToString() + "\r\n");
                    return -1;
                }
                else
                {
                    //Console.WriteLine("---[Request]---Send REQ Msg OK!");
                    LogInfo("Send REQ Msg OK! \r\n");
                }
            }
            return 0;
        }
        /// <summary>
        /// Request One Msg To Replier.
        /// </summary>
        /// <param name="sendMsg"></param>
        /// <param name="rcvdMsg"></param>
        /// <returns>
        /// -1: Connect target failed;
        /// -2: Send message failed;
        /// -3: Set ZMQ Socket option failed;
        /// -4: Get ZMQ Socket Option ZSocketOption.RCVMORE failed;
        /// -5: Disconnect target failed;
        /// -9999: Exception.
        /// </returns>
        public virtual int RequestMsg(string sendMsg, out string rcvdMsg)
        {
            rcvdMsg = string.Empty;
            try
            {
                using (var context = ZContext.Create())
                {
                    LogInfo("Create ZMQ Context OK! ");
                    ZError error;
                    using (var socket = new ZSocket(context, ZSocketType.REQ))
                    {
                        LogInfo("Create ZMQ Socket OK! ");
                        bool isConOK = socket.Connect(Address, out error);
                        if (!isConOK)
                        {
                            //Console.WriteLine("---[Request]---Fail to Connected To Target Address: " + Address);
                            LogInfo("---[Request]---Fail to Connected To Target Address: " + Address);
                            rcvdMsg = string.Empty;
                            return -1;
                        }
                        else
                        {
                            //Console.WriteLine("---[Request]---Connected To Target Address: " + Address);
                            LogInfo("---[Request]---Connected To Target Address: " + Address);
                        }

                        using (var msgFrame = new ZFrame(sendMsg))
                        {
                            //bool rst = socket.SetOption(ZSocketOption.RCVTIMEO, 3);
                            //if (false == rst) { Msg2UI("SeqListener:InitialSeq()--->ZMQ Socket SetOption Fail!\r\n"); }
                            //Msg2UI("SeqRequester:RequestMsg()--->ZMQ Socket SetOption OK!\r\n");
                            bool isSndOK = socket.Send(msgFrame, ZSocketFlags.DontWait, out error);
                            if (!isSndOK)
                            {
                                //Console.WriteLine("---[Request]---Send Msg Fail! " + error.ToString());
                                LogError("Send Msg Fail! " + error.ToString() + "\r\n");
                                rcvdMsg = string.Empty;
                                return -2;
                            }
                            else
                            {
                                //Console.WriteLine("---[Request]---Send REQ Msg OK!");
                                LogInfo("Send REQ Msg OK! \r\n");
                            }
                        }

                        List<ZFrame> frameList = new List<ZFrame>();
                        //ZError error;
                        bool isSetOK = socket.SetOption(ZSocketOption.RCVTIMEO, 3);
                        if (false == isSetOK)
                        {
                            //Console.WriteLine("---[Request]------>ZMQ Socket SetOption Fail!");
                            LogError("ZMQ Socket SetOption Fail!\r\n");
                            rcvdMsg = string.Empty;
                            return -3;
                        }
                        else
                        {
                            //Console.WriteLine("---[Request]------>ZMQ Socket SetOption ZSocketOption.RCVTIMEO(3) OK!");
                            LogInfo("---[Request]------>ZMQ Socket SetOption ZSocketOption.RCVTIMEO(3) OK!\r\n");
                        }

                        //Thread.Sleep(100);

                        ZMessage zm = new ZMessage();
                        ZPollItem zp = ZPollItem.CreateReceiver();
                        bool isOk = socket.Poll(zp, ZPoll.In, ref zm, out error);
                        if (isOk)
                        {
                            StringBuilder str = new StringBuilder();
                            foreach (ZFrame frame in zm)
                            {
                                str.Append(frame.ReadString() /*+ MSG_SEP*/);
                                frame.Dispose();
                            }
                            rcvdMsg = str.ToString();
                            LogInfo("The Entire Reply Msg: \r\n" + str.ToString());
                            CallReplyMsgHandler(rcvdMsg);
                           
                        }

                    }
                }
            }
            catch (SystemException e)
            {
                LogError(e.Message);
                rcvdMsg = string.Empty;
                return -9999;
            }
            return 0;
        }

        /// <summary>
        /// Request one msg to replier with assigned address. 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="sendMsg"></param>
        /// <param name="rcvdMsg"></param>
        /// <returns></returns>
        public virtual int RequestMsg(string address, string sendMsg, out string rcvdMsg)
        {
            Address = address;
            rcvdMsg = string.Empty;
            
            return RequestMsg(sendMsg, out rcvdMsg);
        }

    }
}
