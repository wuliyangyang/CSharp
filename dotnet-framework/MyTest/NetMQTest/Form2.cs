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
using NetMQ.Sockets;
using LogToolLib;
using System.Threading;


namespace NetMQTest
{
    public partial class Form2 : Form
    {
        private readonly object locker = new object();
        private string _xpubaddress = "tcp://127.0.0.1:6720";


        Proxy proxy;
        XSubscriberSocket xsub;
        XPublisherSocket xpub;

        PubSocket _pub;
        PubSocket _pub1;
        PubSocket _pub2;
        PubSocket _pub3;


        SubSocket _sub;
        SubSocket _sub1;
        SubSocket _sub2;
        SubSocket _sub3;
        public Form2()
        {
            InitializeComponent();
            Init0();
        }

        private void Init0()
        {
            string _address = "tcp://127.0.0.1:6721";
            _pub = new PubSocket();
            _pub.Bind(_address);
            _pub.Topic = "topic";
            _pub.PubMsg = "hello!!!";

            string _address1 = "tcp://127.0.0.1:6722";
            _pub1 = new PubSocket();
            _pub1.Bind(_address1);
            _pub1.Topic = "topic1";
            _pub1.PubMsg = "hello1!!!";

            //string _address2 = "tcp://127.0.0.1:6723";
            //_pub2 = new PubSocket();
            //_pub2.Bind(_address2);
            //_pub2.Topic = "topic2";
            //_pub2.PubMsg = "hello2!!!";

            //string _address3 = "tcp://127.0.0.1:6724";
            //_pub3 = new PubSocket();
            //_pub3.Bind(_address3);
            //_pub3.Topic = "topic3";
            //_pub3.PubMsg = "hello3!!!";


            _sub = new SubSocket();
            _sub.SetTopic();
            _sub.Name = "sub0";
            _sub.Connect(_xpubaddress);
            _sub.RecvMsgEvt += OnSubMsgHandler;

            _sub1 = new SubSocket();
            _sub1.SetTopic("topic1");
            _sub1.Connect(_xpubaddress);
            _sub1.RecvMsgEvt += OnSubMsgHandler;

            //_sub2 = new SubSocket();
            //_sub2.SetTopic("topic2");
            //_sub2.Connect(_xpubaddress);
            //_sub2.RecvMsgEvt += OnSubMsgHandler;

            //_sub3 = new SubSocket();
            //_sub3.SetTopic("topic3");
            //_sub3.Connect(_xpubaddress);
            //_sub3.RecvMsgEvt += OnSubMsgHandler;

            var xpubSocket = new XPublisherSocket();
            xpubSocket.Bind(_xpubaddress);
            var xsubSocket = new XSubscriberSocket();

            try
            {

                xsubSocket.Connect(_address);
                xsubSocket.Connect(_address1);
                //xsubSocket.Connect(_address2);
                //xsubSocket.Connect(_address3);

                Console.WriteLine("Intermediary started, and waiting for messages");

                proxy = new Proxy(xsubSocket, xpubSocket);
                Task.Factory.StartNew(proxy.Start);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
        private void OnSubMsgHandler(object sender, string msg)
        {
            lock (locker)
            {
                SubSocket sub = sender as SubSocket;
                this.Invoke(new Action(() =>
                {
                    Console.WriteLine(_sub.Topic+":"+sub.Name + "\r\n");
                    Console.WriteLine("msg:" + msg + "\r\n");
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Task.Factory.StartNew(_pub.StartPub);
                Task.Factory.StartNew(_pub1.StartPub);
                //Task.Factory.StartNew(_pub2.StartPub);
                //Task.Factory.StartNew(_pub3.StartPub);
                //_pub.StartPub(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff") + ":" + i.ToString());
                //_pub1.StartPub(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff") + ":" + i.ToString());
                //_pub2.StartPub(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff") + ":" + i.ToString());
                //_pub3.StartPub(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.fff") + ":" + i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _sub.StartSub();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _pub.StopPub();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _sub.Disconnet();
        }
    }
}
