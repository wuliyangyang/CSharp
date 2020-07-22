using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using NetMQ;
using LogTool;
using NetMQ.Sockets;
using System.Threading;


namespace MNetMQ
{
    public class ReqSocket: ISocket
    {

        private RequestSocket _req;
        private Thread _workThread;
        private bool _isReadyRecv;
        private bool _isReadySend;
        /// <summary>
        /// 需要连接的地址，如tcp://127.0.0.1:8899
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 服务器的名字，默认REQ
        /// </summary>
        public string Name { get; set; }
        public ReqSocket()
        {
            InitMembers();
        }
        ~ReqSocket()
        {
            //false表示：不等待消息处理完直接清空所有配置，
            NetMQ.NetMQConfig.Cleanup(false);
        }
        private void InitMembers()
        {
            _req = new RequestSocket();
            Address = "";
            Name = "REQ";
            _isReadyRecv = false;
            _isReadySend = true;
        }

        private void InitWorkThread()
        {
            _workThread = new Thread(OnWorkThreadRun);
            _workThread.IsBackground = true;
            _workThread.Start();
        }
        private void StopWorkThread()
        {
            if (_workThread.IsAlive) _workThread.Abort();

        }

        private void OnWorkThreadRun()
        {
           
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage(string msg)
        {
            try
            {
                if (!_isReadySend)
                {
                    Log.LogWarn("[Req]you can not send message twice.");
                    return;
                }
                _req.SendFrame(msg);
                Log.LogInfo("[Req]Send Msg:" + msg);
                _isReadyRecv = true;
                _isReadySend = false;
            }
            catch (Exception e)
            {
                Log.LogError("[Req]SendMessage:" + e.Message);
            }
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <returns></returns>
        public string RecvMessage()
        {
            if (!_isReadyRecv)
            {
                Log.LogWarn("[Req]before send,you can not Recv Message.");
                return "";
            }
            try
            {
                string RecvStr = _req.ReceiveFrameString();
                Log.LogInfo("[Req]Recv Msg:" + RecvStr);
                _isReadyRecv = false;
                _isReadySend = true;
                return RecvStr;
            }
            catch (Exception e)
            {
                Log.LogInfo("[Req]RecvMessage:" + e.Message);
                return e.Message;
            }
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Connect(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                Log.LogError("[Req]:Connect to sever address:" + Address + "fail;" + " [error]:address IsNullOrEmpty");
                return -1;
            }
            Address = address;
            try
            {
                _req.Connect(address);
                Log.LogInfo("[Req]:Connect to sever address:" + Address + " successful");

            }
            catch (Exception e)
            {
                Log.LogError("Connect to sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
           
            return 0;
        }
        /// <summary>
        /// 断开服务器
        /// </summary>
        public void Disconnect()
        {
            try
            {
                StopWorkThread();

                _req.Disconnect(Address);
                Log.LogInfo("Disconnect sever address:" + Address + " successful");

            }
            catch (Exception e)
            {
                Log.LogError("Disconnect sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public string PrintSocketType()
        {
            return "Req";
        }
    }
}
