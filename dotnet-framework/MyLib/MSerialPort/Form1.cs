using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LogToolLib;
using RJCP.IO.Ports;

namespace MSerialPort
{

    public partial class Form1 : Form
    {
        SerialPortStream mySP;
        public Form1()
        {
            InitializeComponent();
            InitSerialPort();
        }

        private void InitSerialPort()
        {
            mySP = new SerialPortStream();
            mySP.BaudRate = 115200;
            mySP.PortName = "COM5";

            mySP.DataReceived += MySP_DataReceived;
            mySP.ErrorReceived += MySP_ErrorReceived;

            mySP.ReadTimeout = 3000;

            mySP.Open();
            mySP.WriteLine("hello!!!");
        }

        private void MySP_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Log.LogError(e.EventType.ToString());
        }

        private void MySP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str = mySP.ReadLine();
            Log.LogDebug(String.Format("SerialDataReceivedEventArgs:{0} ; read datastr:{1}", e.EventType, str));
        }
    }
}
