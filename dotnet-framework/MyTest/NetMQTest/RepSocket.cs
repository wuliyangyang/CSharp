using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetMQ;
using LogToolLib;
using NetMQ.Sockets;
using System.Threading;

namespace NetMQTest
{
    public class RepSocket
    {
        public event PostMsgHandler RespMsgHandler;

        private ResponseSocket _rep;
        private Thread _workThread;
        private bool _isReadyRecv;
        private bool _isReadySend;
        private NetMQPoller _poller;

        public string Address { get; set; }
        public string Name { get; set; }
        public RepSocket()
        {
            InitMenbers();
        }

        private void InitMenbers()
        {
            _rep = new ResponseSocket();
            Address = "";
            Name = "";
            _isReadyRecv = true;
            _isReadySend = false;

            //_rep.ReceiveReady += _rep_ReceiveReady; ;
            //_poller = new NetMQPoller { _rep };
            //_poller.RunAsync();
            

            InitWorkThread();
        }

        private void _rep_ReceiveReady(object sender, NetMQSocketEventArgs e)
        {
            Console.WriteLine("_rep_ReceiveReady");
            string RecvStr = e.Socket.ReceiveFrameString();
            _isReadySend = true;
            Log.LogInfo("[Rep]Recv Msg:" + RecvStr);
            if (RespMsgHandler != null)
            {
                RespMsgHandler.Invoke(this, RecvStr);
            }
            _isReadyRecv = false;
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
                    if (!_isReadyRecv) continue;
                    string RecvStr = _rep.ReceiveFrameString();
                    Log.LogInfo("[Rep]Recv Msg:" + RecvStr);
                    if (RespMsgHandler!=null)
                    {
                        RespMsgHandler.Invoke(this, RecvStr);
                    }
                    _isReadySend = true;
                    _isReadyRecv = false;
                }
            }
            catch (Exception e)
            {
                Log.LogError("OnWorkThread:" + e.Message);
                _poller.StopAsync();
                NetMQ.NetMQConfig.Cleanup();
            }

        }

        public void SendMessage(string msg)
        {
            try
            {
                if (!_isReadySend) return;
                _rep.SendFrame(msg);
                Log.LogInfo("[Rep]Send Msg:" + msg);
                _isReadySend = false;
                _isReadyRecv = true;
            }
            catch (Exception)
            {
                _poller.StopAsync();
                NetMQ.NetMQConfig.Cleanup();
            }
        }

        public string RecvMessage()
        {
            return _rep.ReceiveFrameString();
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
    }
}
