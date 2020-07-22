using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTool.UserControls
{
    public partial class TcpPanel : UserControl, IPanelUser
    {

        public event PostMsg Evt_PostMsg;
        public event PostMsgHandler Evt_Connect;
        public event PostMsgHandler Evt_DisConnect;
        public event PostMsgHandler Evt_Start;
        public event PostMsgHandler Evt_Stop;
        public event PostMsgHandler Evt_ActionStart;
        //TcpServerConfigBar ServerConfigBar;
        //TcpClientConfigBar ClientConfigBar;

        //TcpClient client;
        //TcpServer server;
        BaseSocket socket;
        BaseBar Bar;
        public Model Model { get { return Model.Tcp; } }
        public SocketType Type { get; private set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public TcpPanel(SocketType tcpType)
        {
            this.Type = tcpType;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.logPanel1.Clear();
            AddConfigBar(this.Type);
            InitEvent();
        }
        private void AddConfigBar(SocketType type)
        {
            if (type == SocketType.TcpClient)
            {
                Bar = new TcpClientConfigBar(type);
                socket = new TcpClient(Bar.IP, int.Parse(Bar.Port));

            }
            else if (type == SocketType.TcpServer)
            {
                Bar = new TcpServerConfigBar(type);
                socket = new TcpServer(Bar.IP, int.Parse(Bar.Port));

            }
            else
            {
                Bar = new BaseBar(type);
            }
            Bar.Location = new Point(15, 3);
            this.Controls.Add(Bar);
        }

        private void UpdateConfig()
        {
            socket.SetConfig(Bar.IP, int.Parse(Bar.Port));
            this.IP = Bar.IP;
            this.Port = Bar.Port;
        }
        private void InitEvent()
        {
            this.sendMsgPanel1.Evt_SendCommand += PostCmdMsg;
            if (Bar != null)
            {
                this.Bar.Evt_ConnectServer += ClientConfigBar_Evt_ConnectServer;
                this.Bar.Evt_DisConnectServer += ClientConfigBar_Evt_DisConnectServer;
                this.Bar.Evt_StartServer += ServerConfigBar_Evt_StartServer;
                this.Bar.Evt_StopServer += ServerConfigBar_Evt_StopServer;
            }
            if (socket != null)
            {
                this.socket.Evt_RecvMsg += Socket_Evt_RecvMsg;
                this.socket.Evt_SendMsg += Socket_Evt_SendMsg;
                this.socket.Evt_ErrorMsg += Socket_Evt_ErrorMsg;
            }
        }

        #region socket Event
        private void Socket_Evt_ErrorMsg(string msg)
        {
            Bar.SetBtnState("error");
        }

        private void Socket_Evt_SendMsg(string msg)
        {
            ShowLog("Send", msg);
        }

        private void Socket_Evt_RecvMsg(string msg)
        {
            ShowLog("Recv", msg);
        }
        #endregion

        #region log method
        private void ShowLog(string type, string msg)
        {
            //string newMsg = msg.Replace("\\r\\n", ""); 
            switch (type)
            {
                case "Recv":
                    logPanel1.RecvLog = LogFormat(msg);
                    break;
                case "Send":
                    logPanel1.SendLog = LogFormat(msg);
                    break;
                default:
                    break;
            }
        }
        private string LogFormat(string msg)
        {
            return checkBoxTimestamp.Checked ? "[" + CommonLibs.Functions.GetTimeStamp() + "]:" + msg : msg;
        }
        #endregion

        #region ConfigBar_Evt
        private bool ServerConfigBar_Evt_StopServer(string ip, string port)
        {
            if (Evt_Stop != null)
            {
                this.Evt_Stop.Invoke(this);
            }
            return socket.Stop();
        }

        private bool ServerConfigBar_Evt_StartServer(string ip, string port)
        {
            UpdateConfig();
            if (Evt_Start != null)
            {
                this.Evt_Start.Invoke(this);

            }
            if (Evt_ActionStart != null)
            {
                this.Evt_ActionStart.Invoke(this);
            }
            return socket.Start();
        }

        private void PostCmdMsg(string cmd)
        {
            if (Evt_PostMsg != null)
            {
                this.Evt_PostMsg.Invoke(cmd);
            }
            socket.SendString(cmd);
        }
        private bool ClientConfigBar_Evt_DisConnectServer(string ip, string port)
        {
            if (Evt_DisConnect != null)
            {
                this.Evt_DisConnect.Invoke(this);
            }
            return socket.Disconnect();
        }

        private bool ClientConfigBar_Evt_ConnectServer(string ip, string port)
        {
            UpdateConfig();
            if (Evt_Connect != null)
            {
                this.Evt_Connect.Invoke(this);
            }
            if (Evt_ActionStart != null)
            {
                this.Evt_ActionStart.Invoke(this);
            }
            return socket.Connect();
        }
        #endregion
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.logPanel1.Clear();
        }

        public void MDispose()
        {
            switch (this.Type)
            {
                case SocketType.TcpServer:
                    socket.Stop();
                    break;
                case SocketType.TcpClient:
                    socket.Disconnect();
                    break;
                case SocketType.SerialPort:
                    break;
                case SocketType.Rep:
                    break;
                case SocketType.Req:
                    break;
                case SocketType.Pub:
                    break;
                case SocketType.Sub:
                    break;
                default:
                    break;
            }
            socket = null;
        }
    }
}
