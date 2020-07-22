using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Config;
using SuperSocket.Facility;
using SuperSocket.SocketEngine.Configuration;
using SuperSocket.ClientEngine;
using Newtonsoft;
using LogTool;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        private string _ip;
        private int _port;
        AsyncTcpSession client;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitClientEvent()
        {
            client.Connected += OnConnected;
            client.Closed += OnClosed;
            client.DataReceived += OnDataReceived;
            client.Error += OnError;
        }
        private void InitClient()
        {
            client = new AsyncTcpSession();
            InitClientEvent();
            _ip = "127.0.0.1";
            _port = 6000;
            EndPoint ep = new IPEndPoint(IPAddress.Parse(_ip), _port);
            client.Connect(ep);

        }
        private void OnConnected(object sender, EventArgs e)
        {
            Log.LogInfo(string.Format("connect to server ip:{0} port:{1}", _ip, _port));
        }
        private void OnDataReceived(object sender, DataEventArgs e)
        {
            string dataStr = ASCIIEncoding.Default.GetString(e.Data, e.Offset, e.Length);
            Log.LogInfo("recv data:" + dataStr);
        }
        private void OnError(object sender, ErrorEventArgs e)
        {
            Log.LogError(e.ToString());
        }
        private void OnClosed(object sender, EventArgs e)
        {
            Log.LogInfo(e.ToString());
        }
    }
}
