using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SuperSocket;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Config;
using SuperSocket.Facility;
using SuperSocket.SocketEngine;
using SuperSocket.Common;
using Newtonsoft;
using LogTool;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        AppServer server;
        public Form1()
        {
            InitializeComponent();
            InitServer();
        }


        private void InitServer()
        {
            server = new AppServer();
            ServerConfig config = new ServerConfig();
            config.Ip = "127.0.0.1";
            config.Port = 6000;
            InitEvent();
            if (!server.Setup(config))
            {
                Log.LogError("Failed to SetUp");
                return;
            }
            if (!server.Start())
            {
                Log.LogError("Failed to Start");
                return;
            }
            Log.LogInfo(string.Format("start server -->>ip:{0},port:{1}", config.Ip, config.Port.ToString()));
        }
        private void InitEvent()
        {
            server.NewSessionConnected += OnNewSessionConnected;
            server.NewRequestReceived += OnNewRequestReceived;
            server.SessionClosed += OnSessionClosed;

        }
        private void OnNewSessionConnected(AppSession session)
        {
            Log.LogInfo("New Session Connected");
        }
        //Cmd的命令行模式，列如 ADD A A \r\n，ADD即为命令头，A A为命令参数，\r\n截止符（表示这段数据的截止位）
        private void OnNewRequestReceived(AppSession session, StringRequestInfo msg)
        {
            Log.LogInfo("New Request Received key:" + msg.Key);
            Log.LogInfo("New Request Received body:" + msg.Body);
            Log.LogInfo("New Request Received dataStr:" + msg.Key + msg.Body);
            session.Send("feedback msg");
        }
        private void OnSessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason reason)
        {
            Log.LogInfo("Session Closed" + reason.ToString());
        }
    }
}
