using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyZMQ
{
    public partial class Form2 : Form
    {
        private Action<string> actionDelegate1;
        private Action<string> actionDelegate3;
        Replier myRep;
        Requeseter myReq;

        private readonly object lockObj = new object();
        public Form2()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            myRep = new Replier();
            myRep.InitServer("tcp://127.0.0.1:8800");
            myRep.OnMessage_Evt += On_REP_RecvMessageHandler;
            myRep.LogInfo_Evt += LogInfo;
            myRep.LogError_Evt += LogError;


            myReq = new Requeseter();
            myReq.Address = "tcp://127.0.0.1:8800";
            myReq.InitServer(myReq.Address);
            myReq.OnRecvMessage_Evt += On_REQ_RecvMessageHandler;
            myReq.LogInfo_Evt += LogInfo;
            myReq.LogError_Evt += LogError;
            myReq.Start();

            actionDelegate1 = (x) => { textBox1.AppendText(x.ToString()); };
            actionDelegate3 = (x) => { textBox3.AppendText(x.ToString()); };
        }

        private void ShowMsg(object sender, string msg)
        {
            BaseSocket BS = sender as BaseSocket;
            if (BS.Name== "Rep")
            {
                msg = Global.GetDateTimeString() + "[Replier] " + msg + "\r\n";
                if (textBox3.InvokeRequired)
                {
                    textBox3.BeginInvoke(actionDelegate3, msg);
                }
                else
                {
                    textBox3.AppendText(msg);
                }
            }
            else if (BS.Name == "Req")
            {
                msg = Global.GetDateTimeString() + "[Request] " + msg + "\r\n";
                if (textBox1.InvokeRequired)
                {
                    textBox1.BeginInvoke(actionDelegate1, msg);
                }
                else
                {
                    textBox1.AppendText(msg);
                }
            }
           
        }
        private void LogInfo(object sender, string msg)
        {
            lock (lockObj)
            {
                ShowMsg(sender, msg);
            }
           
        }
        private void LogError(object sender, string msg)
        {
            lock (lockObj)
            {
                ShowMsg(sender, msg);
            }
            
        }
        public void On_REP_RecvMessageHandler(object sender, string msg)
        {
            LogInfo(sender, msg);
            //todo

            On_Rep_MessageHandler(sender, msg);
        }
        private void On_Rep_MessageHandler(object sender, string msg)
        {
            //todo
            myRep.RepMsg = "give back msg";
        }

        public void On_REQ_RecvMessageHandler(object sender, string msg)
        {
            LogInfo(sender, msg);
            //todo

            On_Req_MessageHandler(sender, msg);
        }
        private void On_Req_MessageHandler(object sender, string msg)
        {
           //todo
        }

        private string ReqMsg(string msg)
        {
            string recvMsg=string.Empty;
            myReq.RequestMsg(myReq.Address,msg,out recvMsg);
            return recvMsg;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            myRep.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myRep.Stop();
            myRep.EndServer(myRep.Address);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myReq.RequestMsg("oooooooo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = ReqMsg("Request msg!!!!");
        }
    }
}
