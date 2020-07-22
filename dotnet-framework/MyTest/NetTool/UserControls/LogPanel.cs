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
    public partial class LogPanel : UserControl
    {
        public LogPanel()
        {
            InitializeComponent();
        }

        public string RecvLog
        {
            get { return this.textBoxRecv.Text; }
            set { UpdateRecvLog(value); }
        }
        private void UpdateRecvLog(string content)
        {
            if (this.InvokeRequired) Invoke(new Action<string>(SetRecvLogString), content);
            else SetRecvLogString(content);
        }
        private void SetRecvLogString(string content)
        {
            if (content.EndsWith("\r\n"))
            {
                this.textBoxRecv.AppendText(content);
            }
            else
            {
                this.textBoxRecv.AppendText(content + "\r\n");
            }
        }

        public string SendLog
        {
            get { return this.textBoxSend.Text; }
            set { UpdateSendLog(value); }
        }
        private void UpdateSendLog(string content)
        {
            if (this.InvokeRequired) Invoke(new Action<string>(SetSendLogString), content);
            else SetSendLogString(content);
        }
        private void SetSendLogString(string content)
        {
            if (content.EndsWith("\r\n"))
            {
                this.textBoxSend.AppendText(content);
            }
            else
            {
                this.textBoxSend.AppendText(content + "\r\n");
            }
           
        }

        public void Clear()
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    textBoxRecv.Clear();
                    textBoxSend.Clear();
                }));
            }
            else
            {
                textBoxRecv.Clear();
                textBoxSend.Clear();
            }
        }
    }
}
