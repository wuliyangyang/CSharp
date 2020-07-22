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
using System.ComponentModel;

namespace NetMQTest
{
    public class ReqSocket
    {

        private RequestSocket _req;
        //private NetMQPoller _poller;
        /// <summary>
        /// address of server
        /// </summary>

        public string Address { get; set; }
        public string Name { get; set; }
        public ReqSocket()
        {
            InitMenbers();
        }

        private void InitMenbers()
        {
            _req = new RequestSocket();
            Address = "";
            Name = "";
            
        }

        public void SendMessage(string msg)
        {
            _req.SendFrame(msg);
            Log.LogInfo("[Req]Send Msg:" + msg);
           // RecvMessage();
        }

        public string RecvMessage()
        {
            //TimeSpan ts = TimeSpan.FromMilliseconds(200);
            string RecvStr = _req.ReceiveFrameString();
            Log.LogInfo("[Req]Recv Msg:" + RecvStr);
            Console.WriteLine("[Req]Recv Msg:" + RecvStr);
            return RecvStr;
        }

        /// <summary>
        /// 绑定服务器
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
                _req.Connect(address);
                Log.LogInfo("Connect to sever address:" + Address + " successful");

               
            }
            catch (Exception e)
            {
                Log.LogError("Connect to sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
           
            return 0;
        }
        /// <summary>
        /// 解绑服务器
        /// </summary>
        public void Disconnect()
        {
            try
            {
                _req.Disconnect(Address);
                Log.LogInfo("Disconnect sever address:" + Address + " successful");
                NetMQ.NetMQConfig.Cleanup();
            }
            catch (Exception e)
            {
                Log.LogError("Disconnect sever address:" + Address + "fail;" + "[error]:" + e.Message);
                MessageBox.Show(e.Message);
            }
        }
    }
}
