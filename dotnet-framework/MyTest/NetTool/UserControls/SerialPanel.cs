using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using RJCP.IO.Ports;

namespace NetTool.UserControls
{
    public partial class SerialPanel : UserControl, IPanelUser
    {
        public event PostMsgHandler Evt_ActionStart;

        SerialPortStream mySP;
        public int BaudRate{get{ return int.Parse(comboBoxRate.Text);}}
        public string PortName { get { return comboBoxCOM.Text; }}

        public Model Model
        {
            get
            {
                return Model.Serial;
            }
        }

        public SerialPanel()
        {
            InitializeComponent();
            this.logPanel1.Clear();
            InitSerialPort();
        }

      
        private void InitSerialPort()
        {
            mySP = new SerialPortStream();
            mySP.ReadTimeout = 3000;
            InitEvent();
        }

        private void InitEvent()
        {
            mySP.DataReceived += MySP_DataReceived;
            mySP.ErrorReceived += MySP_ErrorReceived;
            this.sendMsgPanel1.Evt_SendCommand += SendMsgPanel1_Evt_SendCommand; ;
        }

        private void SendMsgPanel1_Evt_SendCommand(string cmd)
        {
            SendString(cmd);
        }

        public void OpenPort()
        {
            try
            {
                if (Config()) mySP.Open();
                else
                    ShowLog(LogMode.Recv, "config fail!!");
            }
            catch (Exception e)
            {
                ShowLog(LogMode.Recv, e.Message);
            }
            

        }
        public void ClosePort()
        {
            mySP.Close();
        }
        private bool Config()
        {
            if (string.IsNullOrWhiteSpace(comboBoxRate.Text)) return false;
  
            mySP.BaudRate = int.Parse(comboBoxRate.Text);
            mySP.PortName = comboBoxCOM.Text;
            return true;
        }
        public void SendString(string msg)
        {
            if (mySP.IsOpen)
            {
                mySP.WriteLine(msg);
                ShowLog(LogMode.Send, msg);
                return;
            }
            ShowLog(LogMode.Recv, "Port is not opened");
        }
        private void MySP_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            ShowLog(LogMode.Recv, e.ToString());
        }

        private void MySP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str = mySP.ReadLine();
            ShowLog(LogMode.Recv, str);
        }

        public void MDispose()
        {
            ClosePort();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Evt_ActionStart != null)
            {
                this.Evt_ActionStart.Invoke(this);
            }
            OpenPort();
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            ClosePort();
        }

        #region log method
        private void ShowLog(LogMode mode, string msg)
        {
            //string newMsg = msg.Replace("\\r\\n", ""); 
            switch (mode)
            {
                case LogMode.Recv:
                    logPanel1.RecvLog = LogFormat(msg);
                    break;
                case LogMode.Send:
                    logPanel1.SendLog = LogFormat(msg);
                    break;
                default:
                    break;
            }
        }
        private string LogFormat(string msg)
        {
            return checkBoxTimeStamp.Checked ? "[" + CommonLibs.Functions.GetTimeStamp() + "]:" + msg : msg;
        }
        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.logPanel1.Clear();
        }
        private string[] GetSysPort()
        {
            string[] ports =  System.IO.Ports.SerialPort.GetPortNames();
            return ports;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = GetSysPort();
            this.Invoke(new Action(() =>
            {
                comboBoxCOM.Items.AddRange(ports.ToArray());
            }));
            Console.WriteLine("scan ports");
        }
    }
}
