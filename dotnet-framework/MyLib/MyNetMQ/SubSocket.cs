using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using NetMQ;
using LogTool;
using NetMQ.Sockets;
using System.ComponentModel;

namespace MNetMQ
{
    public class SubSocket: ISocket
    {

        public event RecvMsgHandler RecvMsgEvt;

        private SubscriberSocket _sub;
        private Thread _workThread;
        private string _topicRecv;
        private bool _isStartSub;
        private bool _isThreadRuning;
        public string Address { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 需要订阅的主题，默认为空
        /// </summary>
        public string Topic { get { return _topicRecv; } }
        public SubSocket()
        {
            InitMembers();
        }
         ~SubSocket()
        {
            //false表示：不等待消息处理完直接清空所有配置，
            NetMQ.NetMQConfig.Cleanup(false);
        }
        private void InitMembers()
        {
            _sub = new SubscriberSocket();
            _sub.Options.SendHighWatermark = 1000;
            _isStartSub = false;
            _isThreadRuning = false;
            _topicRecv = "";
            Name = "SubSocket";
            Address = "";
            //InitWorkThread();
        }
        /// <summary>
        /// 设置主题，默认为空，即订阅所有消息
        /// </summary>
        /// <param name="topic"></param>
        public void SetTopic(string topic = "")
        {
            _sub.Subscribe(topic);
        }
        private int InitWorkThread()
        {
            if (_isThreadRuning == true) return -1;
            _workThread = new Thread(OnWorkThreadRun);
            _workThread.IsBackground = true;
            _workThread.Start();
            _isThreadRuning = true;
            return 0;
        }

        private void StopWorkThread()
        {
            if (_workThread.IsAlive) _workThread.Abort();

        }
        private void OnWorkThreadRun()
        {
            try
            {
                //Log.LogInfo("Start Recv Msg...");
                while (_isStartSub)
                {
                    //string messageTopicReceived = _sub.ReceiveFrameString();
                    string messageReceived = _sub.ReceiveFrameString();
                    //_topicRecv = messageTopicReceived;
                    if (RecvMsgEvt!=null)
                    {
                        RecvMsgEvt.Invoke(this, messageReceived);
                    }
                    
                }

            }
            catch (Exception e)
            {
                _isThreadRuning = false;
                Log.LogError("OnWorkThread:" + e.Message);
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
                Log.LogError("Connect to sever address:" + Address + "fail;" + " [error]:address IsNullOrEmpty");
                return -1;
            }
            Address = address;
            try
            {
                _sub.Connect(address);
                Log.LogInfo("Connect to  sever address:" + Address + " successful");
            }
            catch (Exception e)
            {
                _isThreadRuning = false;
                Log.LogError("Connect to  sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }

            return 0;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnet()
        {
            try
            {
                _isStartSub = false;
                _isThreadRuning = false;
                StopWorkThread();
                _sub.Disconnect(Address);
                Log.LogInfo("Disconnect sever address:" + Address + " successful");

            }
            catch (Exception e)
            {
                Log.LogError("Disconnect sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public void StartSub()
        {
            Log.LogInfo("StartSub...");
            _isStartSub = true;
            int ret = InitWorkThread();
            Log.LogInfo("InitWorkThread result:" + ret.ToString());
        }
        private void StopSub()
        {
            Log.LogInfo("StopSub...");
            _isStartSub = false;
        }

        public string PrintSocketType()
        {
            return "Sub";
        }
    }
}
