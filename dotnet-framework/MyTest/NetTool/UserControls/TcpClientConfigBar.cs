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
    public partial class TcpClientConfigBar : BaseBar, IBar
    {

        public TcpClientConfigBar(SocketType type):base(type)
        {
            InitializeComponent();
            btnDisConnect.Enabled = false;
        }

        public override string IP
        {
            get { return this.textBoxIP.Text; }
            set { UpdateIP(value); }
        }
        private void UpdateIP(string IP)
        {
            if (this.InvokeRequired) Invoke(new Action<string>(SetIPString), IP);
            else SetIPString(IP);
        }
        private void SetIPString(string IP)
        {
            this.textBoxIP.Text = IP;
        }
        public override string Port
        {
            get { return textBoxPort.Text; }
            set { UpdatePort(value); }
        }

        private void UpdatePort(string port)
        {
            if (this.InvokeRequired) Invoke(new Action<string>(SetPortString), port);
            else SetPortString(port);
        }
        private void SetPortString(string port)
        {
            this.textBoxPort.Text = port;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnDisConnect.Enabled = true;
            ConnectServer();

        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;
            DisConnectServer();
        }

        public override void SetBtnState(string type)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(()
                    =>
                {
                    if (type.ToLower() == "error")
                    {
                        btnConnect.Enabled = true;
                        btnDisConnect.Enabled = false;
                    }
                    else if (type.ToLower() == "good")
                    {
                        btnConnect.Enabled = false;
                        btnDisConnect.Enabled = true;
                    }
                }));
            }
            else
            {
                if (type.ToLower() == "error")
                {
                    btnConnect.Enabled = true;
                    btnDisConnect.Enabled = false;
                }
                else if (type.ToLower() == "good")
                {
                    btnConnect.Enabled = false;
                    btnDisConnect.Enabled = true;
                }
            }
        }
        public override void ConnectServer()
        {
            base.ConnectServer();
        }
        public override void DisConnectServer()
        {
            base.DisConnectServer();
        }
    }
}
