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
    class TcpServer : BaseSocket
    {
        //public event RecvMsgHandler Evt_RecvMsg;

        private bool flag = false;
        private string _dataStr;
        private AppServer server;
        private AppSession _session;
        ServerConfig config;
        public string ID { get; set; }
        public TcpServer(string ip, int port) : base(ip, port, SocketType.TcpServer)
        {
            InitServer();
        }
        #region Server
        private void InitServer()
        {
            server = new AppServer();
            config = new ServerConfig();
            InitEvent();

        }
        private void InitEvent()
        {
            server.NewSessionConnected += OnNewSessionConnected;
            server.NewRequestReceived += OnNewRequestReceived;
            server.SessionClosed += OnSessionClosed;
        }
        public override bool Start()
        {
            try
            {
                if (!flag)
                {

                    if (!server.Setup(this.IP, this.Port))
                    {
                        Log.LogError("Failed to SetUp");
                        RecvMsgHandler("Failed to SetUp");
                        return false;
                    }
                    flag = true;
                }
                if (!server.Start())
                {
                    Log.LogError("Failed to Start");
                    RecvMsgHandler("Failed to Start");
                    return false;
                }
                string msg = string.Format("start server -->>ip:{0},port:{1}", this.IP, this.Port.ToString());
                Log.LogInfo(msg);
                RecvMsgHandler(msg);
            }
            catch (Exception e)
            {
                string error = e.Message;
                Log.LogInfo(error);
                RecvMsgHandler(error);

                return false;
            }
            return true;
        }

        public override bool Stop()
        {
            try
            {
                server.Stop();
                RecvMsgHandler("Stop Server!!");
            }
            catch (Exception e)
            {
                RecvMsgHandler(e.Message);
            }
            return base.Stop();
        }
        public override void RecvMsgHandler(string msg)
        {
            base.RecvMsgHandler(msg);
        }
        public override void SendMsgHandler(string msg)
        {
            base.SendMsgHandler(msg);
        }
        private void OnNewSessionConnected(AppSession session)
        {
            _session = session;
            this.ID = session.RemoteEndPoint.ToString();
            Log.LogInfo("New Session Connected "+this.ID);
            RecvMsgHandler("New Session Connected " + this.ID);
        }
        //Cmd的命令行模式，列如 ADD A A \r\n，ADD即为命令头，A A为命令参数，\r\n截止符（表示这段数据的截止位）
        private void OnNewRequestReceived(AppSession session, StringRequestInfo msg)
        {
            Log.LogInfo("New Request Received dataStr:" + msg.Key + msg.Body);
            _dataStr = msg.Key + msg.Body;
            _session = session;
            RecvMsgHandler(_dataStr);
        }
        private void OnSessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason reason)
        {
            string msg = "Session Closed" + reason.ToString();
            Log.LogInfo(msg);
            RecvMsgHandler(msg);
        }

        public override void SendString(string msg)
        {
            try
            {
                if (server.State == ServerState.NotInitialized)
                {
                    MessageBox.Show("Server NotInitialized");
                    return;
                }
                _session.Send(msg);
                SendMsgHandler(msg);
            }
            catch (Exception)
            {
            }
        }
        public override string ReadString()
        {
            return _dataStr;
        }

        public override void ErrorMsgHandler(string msg)
        {
            base.ErrorMsgHandler(msg);
        }
        #endregion
    }
}
