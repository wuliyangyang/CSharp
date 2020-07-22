using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using SuperSocket;
using SuperSocket.ClientEngine;
using System.Net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using NetTool.UserControls;
using CommonLibs;
using LogTool;
using log4net;

namespace NetTool
{
    class TcpClient : BaseSocket
    {
        AsyncTcpSession client;
        private string _dataStr;
        public TcpClient(string ip, int port) : base(ip, port,SocketType.TcpClient)
        {
            InitClient();
        }

        #region Client
        private void InitClient()
        {
            client = new AsyncTcpSession();
            InitClientEvent();


        }

        public override bool Connect()
        {
            try
            {
                EndPoint ep = new IPEndPoint(IPAddress.Parse(this.IP), this.Port);
                client.Connect(ep);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public override bool Disconnect()
        {
            client.Close();
            return base.Disconnect();
        }
        private void InitClientEvent()
        {
            client.Connected += OnConnected;
            client.Closed += OnClosed;
            client.DataReceived += OnDataReceived;
            client.Error += OnError;
        }
        private void OnConnected(object sender, EventArgs e)
        {
            string msg = string.Format("connect to server ip:{0} port:{1}", this.IP, this.Port);
            Log.LogInfo(msg);
            RecvMsgHandler(msg);

        }
        private void OnDataReceived(object sender, DataEventArgs e)
        {
            _dataStr = ASCIIEncoding.Default.GetString(e.Data, e.Offset, e.Length);
            Log.LogInfo("recv data:" + _dataStr);
            RecvMsgHandler(_dataStr);
        }
        private void OnError(object sender, ErrorEventArgs e)
        {
            string error = e.Exception.Message;
            Log.LogError(error);
            RecvMsgHandler(error);
            ErrorMsgHandler(error);
        }
        private void OnClosed(object sender, EventArgs e)
        {
            string s = "server disconnect!!!";
            Log.LogInfo(s);
            RecvMsgHandler(s);
            ErrorMsgHandler(s);
        }

        public override void SendString(string msg)
        {
            try
            {
                if (!client.IsConnected)
                {
                    MessageBox.Show("Client No Connect");
                    return;
                }
                byte[] buff = Encoding.Default.GetBytes(msg);
                client.Send(buff, 0, buff.Length);
                SendMsgHandler(msg);
            }
            catch (Exception)
            {
                return;
            }


        }
        public override string ReadString()
        {
            return _dataStr;
        }

        public override void RecvMsgHandler(string msg)
        {
            base.RecvMsgHandler(msg);
        }
        public override void SendMsgHandler(string msg)
        {
            base.SendMsgHandler(msg);
        }
        public override void ErrorMsgHandler(string msg)
        {
            base.ErrorMsgHandler(msg);
        }

        #endregion
    }
}
