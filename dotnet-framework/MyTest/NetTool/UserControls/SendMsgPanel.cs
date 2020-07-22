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
    public partial class SendMsgPanel : UserControl
    {
        public delegate void PostMsg(string cmd);
        public event PostMsg Evt_SendCommand;
        public SendMsgPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否循环发送
        /// </summary>
        public bool IsLoop { get {return loopCheckBox.Checked; } }

        public string Interval
        {
            get {
                if (string.IsNullOrWhiteSpace(this.textBoxInterval.Text))
                {
                    return "500";
                }
                else
                {
                   return this.textBoxInterval.Text;
                }
            }
        }

        public string Endding { get { return textBoxEnding.Text; } }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (Evt_SendCommand!=null)
            {
                this.Evt_SendCommand.Invoke(textBoxSend.Text+"\r\n");
                if (!comboBoxCommand.Items.Contains(textBoxSend.Text))
                {
                    comboBoxCommand.Items.Add(textBoxSend.Text);
                }
            }
        }
    }

}
