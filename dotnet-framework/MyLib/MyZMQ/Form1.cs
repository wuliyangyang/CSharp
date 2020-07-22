using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyZMQ.ZMQSocket;

namespace MyZMQ
{
    public partial class Form1 : Form
    {
        Subscribe mySub;
        Publisher myPub;
        Action<string> actionDelegate;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            mySub = new Subscribe();
            mySub.Address = "tcp://127.0.0.1:8899";
            mySub.RecvMsg_Evt += RcveMsgHandler;
            mySub.LogInfo_Evt += RcveMsgHandler;
            mySub.LogError_Evt += RcveMsgHandler;


            myPub = new Publisher();
            myPub.Address = "tcp://127.0.0.1:8899";
            myPub.LogInfo_Evt += PubLogInfo;
            myPub.LogError_Evt += PubLogError;


            actionDelegate = (x) => { textBox1.AppendText(x.ToString()); };
        }

        private void ShowMsgPub(string msg)
        {
            msg = Global.GetDateTimeString() + "[PUBLISH]"+msg + "\r\n";
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox3.AppendText(msg);
                }));
            }
            else
            {
                textBox3.AppendText(msg);
            }
        }
        private void PubLogInfo(object sender, string msg)
        {
            ShowMsgPub(msg);
        }

        private void PubLogError(object sender, string msg)
        {
            ShowMsgPub(msg);
        }
        private void RcveMsgHandler(object sender, string msg)
        {
            msg = Global.GetDateTimeString() +"[Subscriber]"+ msg + "\r\n";
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(actionDelegate, msg);
            }
            else
            {
                textBox1.AppendText(msg);
            }
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySub.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySub.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool isStartOk = myPub.StartServer("tcp://127.0.0.1:8899");
            if (isStartOk)
            {
                myPub.StartPub();
                myPub.StringToBePub = "Test Msg!!!";
                myPub.IsDataReady = true;
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myPub.StopPub();
            myPub.StopServer("tcp://127.0.0.1:8899");
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            myPub.IsDataReady = !myPub.IsDataReady;
        }
    }
}
