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
    public class RepSocket: ISocket
    {
        public event PostMsgHandler RecvMsgEvent;

        private ResponseSocket _rep;
        private Thread _workThread;
        private string _recvStr;
        private bool _isReadyRecv;
        private bool _isReadySend;
        /// <summary>
        /// 需要绑定的地址,如tcp://127.0.0.1:8899
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 服务器的名字，默认REP
        /// </summary>
        public string Name { get; set; }
        public RepSocket()
        {
            InitMembers();
        }
        ~RepSocket()
        {
            //false表示：不等待消息处理完直接清空所有配置，
            NetMQ.NetMQConfig.Cleanup(false);
        }
        private void InitMembers()
        {
            _rep = new ResponseSocket();
            Address = "";
            Name = "REP";
            _isReadyRecv = true;
            _isReadySend = false;
            _recvStr = "";
            InitWorkThread();
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
            try
            {
                while (true)
                {
                    if (!_isReadyRecv)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    
                    string RecvStr = _rep.ReceiveFrameString();
                    Log.LogInfo("[Rep]Recv Msg:" + RecvStr);
                    if (RecvMsgEvent != null)
                    {
                        _isReadySend = true;
                        RecvMsgEvent.Invoke(this, RecvStr);
                    }
                    _isReadyRecv = false;
                }
            }
            catch (Exception e)
            {
                Log.LogError("OnWorkThread:" + e.Message);
            }

        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage(string msg)
        {
            try
            {
                if (!_isReadySend)
                {
                    Log.LogWarn("[Rep]:before receive,you can not send again...sorry!!!");
                    return;
                }
                _rep.SendFrame(msg);
                Log.LogInfo("[Rep]Send Msg:" + msg);
                _isReadyRecv = true;
            }
            catch (Exception e)
            {

                Log.LogError("SendMessage:" + e.Message);
            }
        }
        /// <summary>
        /// 读取接收到的信息
        /// </summary>
        /// <returns></returns>
        public string ReadMessage()
        {
            return _recvStr;
        }
        /// <summary>
        /// 绑定服务器
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Bind(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                Log.LogError("Bind sever address:" + Address + "fail;" + " [error]:address IsNullOrEmpty");
                return -1;
            }
            Address = address;
            try
            {
                _rep.Bind(address);
                Log.LogInfo("Bind sever address:" + Address + " successful");
            }
            catch (Exception e)
            {
                Log.LogError("Bind sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }

            return 0;
        }
        /// <summary>
        /// 解绑服务器
        /// </summary>
        public void Unbind()
        {
            try
            {
                StopWorkThread();

                _rep.Unbind(Address);
                Log.LogInfo("Unbind sever address:" + Address + " successful");

            }
            catch (Exception e)
            {
                Log.LogError("Unbind sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public string PrintSocketType()
        {
            return "Rep";
        }
    }
}
