using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJCP.IO.Ports;

namespace SerialPortTest
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
            mySP.ReadTimeout = 5000;
            
            mySP.Open();
        }

        private void MySP_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            
        }

        private void MySP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string str =  mySP.ReadLine();
            Console.WriteLine("SerialDataReceivedEventArgs:{0}  read datastr:{1}", e.EventType, str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mySP.WriteLine("test string!!");
            }
            catch (Exception ee)
            {

                Console.WriteLine(ee.Message);
            }
            
        }
    }
}
