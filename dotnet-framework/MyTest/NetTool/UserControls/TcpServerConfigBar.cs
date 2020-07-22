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
    public partial class TcpServerConfigBar : BaseBar, IBar
    {
        public TcpServerConfigBar(SocketType type):base(type)
        {
            
            InitializeComponent();
            btnStop.Enabled = false;
            
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            StartServer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            StopServer();
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
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                    }
                    else if (type.ToLower() == "good")
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                    }
                }));
            }
            else
            {
                if (type.ToLower() == "error")
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
                else if (type.ToLower() == "good")
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                }
            }

        }
        public override void StartServer()
        {
            base.StartServer();
        }
        public override void StopServer()
        {
            base.StopServer();
        }
    }
}
