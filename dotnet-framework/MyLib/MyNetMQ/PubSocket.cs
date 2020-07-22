using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

using NetMQ;
using LogTool;
using NetMQ.Sockets;

namespace MNetMQ
{
    public class PubSocket: ISocket
    {
       
        private PublisherSocket _pub;
        private bool _isStartPub;
        private Thread _workThread;

        public string Address { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 需要发布的主题，默认为空
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 需要发布的信息
        /// </summary>
        public string PubMsg { get; set; }
        
        public PubSocket()
        {
            InitMembers();
        }
        ~PubSocket()
        {
            //false表示：不等待消息处理完直接清空所有配置，
            NetMQ.NetMQConfig.Cleanup(false);
        }
        private void InitMembers()
        {
            _pub = new PublisherSocket();
            _pub.Options.SendHighWatermark = 1000;
            _isStartPub = false;
            Name = "PubSocket";
            Address = "";
            PubMsg = "";
            Topic = "";
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
                    while (_isStartPub)
                    {
                        _pub.SendMoreFrame(Topic).SendFrame(PubMsg);
                        Thread.Sleep(5);
                        //_isStartPub = false;
                    }
                }
            }
            catch (Exception e)
            {
                Log.LogError("OnWorkThread:" + e.Message);
            }
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
                _pub.Bind(address);
                Log.LogInfo("Bind sever address:" + Address+" successful");
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
                _isStartPub = false;
                StopWorkThread();

                _pub.Unbind(Address);
                Log.LogInfo("Unbind sever address:" + Address+ " successful");   

            }
            catch (Exception e)
            {
                Log.LogError("Unbind sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 开始不断地PUB信息
        /// </summary>
        public void StartPub()
        {
            _isStartPub = true;
        }
        /// <summary>
        /// 开始不断地PUB信息
        /// </summary>
        /// <param name="msg"></param>
        public void StartPub(string msg)
        {
            PubMsg = msg;
            _isStartPub = true;
        }
        /// <summary>
        /// 停止PUB信息
        /// </summary>
        public void StopPub()
        {
            _isStartPub = false;
        }
        /// <summary>
        /// 仅PUB一条信息
        /// </summary>
        /// <param name="msg"></param>
        public void PubMessage(string msg)
        {
            PubMsg = msg;
            _pub.SendMoreFrame(Topic).SendFrame(PubMsg);
        }

        public string PrintSocketType()
        {
            return "Pub";
        }
    }
}
