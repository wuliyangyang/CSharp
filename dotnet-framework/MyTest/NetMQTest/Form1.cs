using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyNetMQ;
using NetMQ;
using LogToolLib;
using System.Threading;

namespace NetMQTest
{
    public partial class Form1 : Form
    {
        private string _address;

        PubSocket _pub;
        SubSocket _sub;

        NetMQTest.ReqSocket _req;
        NetMQTest.RepSocket _rep;
        
        public Form1()
        {
            InitializeComponent();
            Init0();
            //Init1();
        }

        private void Init1()
        {
            _address = "tcp://127.0.0.1:8800";
            _req = new NetMQTest.ReqSocket();
            _req.Connect(_address);

            _rep = new NetMQTest.RepSocket();
            _rep.Bind(_address);
            _rep.RespMsgHandler += _rep_RespMsgHandler;
        }

        private void _rep_RespMsgHandler(object sender, string msg)
        {
            Console.WriteLine("[Rep] recv msg:" + msg);
            //Thread.Sleep(3000);
            //_rep.SendMessage("world!!!");

        }
        private void Init0()
        {
            _address = "tcp://127.0.0.1:6720";

            _pub = new PubSocket();
            _pub.Bind(_address);
            //_pub.Topic = "topic";
            _pub.PubMsg = "hello!!!";

            _sub = new SubSocket();
            _sub.SetTopic();
            _sub.Connect(_address);
            _sub.RecvMsgEvt += OnSubMsgHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(5);
                _pub.StartPub(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff")+":"+i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _sub.StartSub();

        }

        private void OnSubMsgHandler(object sender, string msg)
        {
            this.Invoke(new Action(() =>
            {
                textBox2.AppendText(_sub.Topic + "\r\n");
                textBox2.AppendText("msg:" + msg + "\r\n");
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _pub.StopPub();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _sub.Disconnet();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _sub.Connect(_address);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _req.SendMessage("hello!!!");
            Console.WriteLine("[Req]Send: hello!!!");
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //just for test 
            Task.Run(() =>
            {
                string msg = _req.RecvMessage();
            });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _rep.SendMessage("feedback msg");
            Console.WriteLine("[Rep]Send:feedback msg");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
