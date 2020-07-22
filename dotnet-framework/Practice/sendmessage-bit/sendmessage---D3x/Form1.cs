using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using CommonDefine;
using System.Threading;
using System.Timers;

namespace sendmessage___D3x
{
    public partial class Form1 : Form
    {
        public int startCmd = 11;
        Dictionary<string, int> dic = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
            IPAddress ip = IPAddress.Parse("169.254.1.22");
            //test(60);

        }
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public double test(int interval)
        {
            if (interval == 0)
            {
                interval = 10;
            }

            DateTime dt = DateTime.Now.AddMinutes(0 - interval);
            //using (alcEntities model = new alcEntities())
            //{
            //    var res = model.productrecord.Where(r => (string.Compare(r.lotId, lotId) == 0)
            //        //&& (getLotInfo().id == r.lotIndex)
            //        && (r.testerId.Contains("-UNLOAD-"))
            //        && (r.dateTime > dt));
            //    if (res.Count() <= 0)
            //    {
            //        return 0;
            //    }
            //    return res.Count() * 60 / interval;
            //}
            return 60 / interval;
        }
        public static byte[] PLCDataToByte(PLCData data)
        {
            byte[] res = new byte[72];

            byte[] cid = System.BitConverter.GetBytes(data.channelId);
            byte[] msgtype = System.BitConverter.GetBytes(data.msgType);
            byte[] cmd = System.BitConverter.GetBytes(data.commandId);
            byte[] p1 = System.BitConverter.GetBytes(data.param1);
            byte[] p2 = System.BitConverter.GetBytes(data.param2);
            byte[] p3 = System.BitConverter.GetBytes(data.param3);
            byte[] p4 = System.BitConverter.GetBytes(data.param4);
            byte[] p5 = System.BitConverter.GetBytes(data.param5);
            byte[] err = System.BitConverter.GetBytes(data.errorcode);
            byte[] msg;
            if (!string.IsNullOrEmpty(data.strMessage))
            {
                msg = Encoding.ASCII.GetBytes(data.strMessage);
            }
            else
            {
                msg = new byte[32];
            }
            int msglen = msg.Length > 32 ? 32 : msg.Length;


            int offset = 0;
            Buffer.BlockCopy(cid, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(msgtype, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(cmd, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(p1, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(p2, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(p3, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(p4, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(p5, 0, res, offset, 4); offset += 4;
            Buffer.BlockCopy(err, 0, res, offset, 8); offset += 8;
            Buffer.BlockCopy(msg, 0, res, offset, msglen);

            return res;
        }
        private static Socket socketcreat(PLCData plcdata)
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            PLCData plcData = new PLCData()
            {

                channelId = int.Parse(tb_channalId.Text),
                msgType = int.Parse(tb_msgType.Text),
                commandId = int.Parse(textBox_commandid.Text),
                param1 = float.Parse(textBox_p1.Text),
                param2 = float.Parse(textBox_p2.Text),
                param3 = float.Parse(textBox_p3.Text),
                param4 = float.Parse(textBox_p4.Text),
                param5 = float.Parse(textBox_p5.Text),
                errorcode = long.Parse(textBox_errcode.Text),
                strMessage = textBox_strMessage.Text.ToString()

            };

            string dataStr = tb_channalId.Text + " " + tb_msgType.Text + " " + textBox_commandid.Text + " " + textBox_p1.Text + " " + textBox_p2.Text + " " + textBox_p3.Text + " " + textBox_p4.Text + " " + textBox_p5.Text + " " + textBox_errcode.Text + " " + textBox_strMessage.Text;
            string str = string.Format("{0} send cmd: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm;ssss"), dataStr);
            textBox1.AppendText(str + "\r\n");

            byte[] sendbuf = Form1.PLCDataToByte(plcData);
            clientSocket.Send(sendbuf);

        }



        private void biglabel_Click(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(TimerMange);
            thread1.IsBackground = true;
            thread1.Start();

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            byte[] result = new byte[1024];
            string IP = textBox2.Text;
            int port = int.Parse(textBox3.Text);
            IPAddress ip = IPAddress.Parse(IP);

            try
            {
                clientSocket.Connect(new IPEndPoint(ip, port));
                biglabel.Text = "succeed";
                aTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                biglabel.Text = "fail";
                Console.WriteLine(ex.Message);
                return;

            }
            //clientSocket.Send(Encoding.ASCII.GetBytes(data.ToString()));
        }

        private void button_zero_Click(object sender, EventArgs e)
        {
            tb_channalId.Text = "0";
            tb_msgType.Text = "0";
            textBox_commandid.Text = "0";
            textBox_errcode.Text = "0";
            textBox_p1.Text = "0";
            textBox_p2.Text = "0";
            textBox_p3.Text = "0";
            textBox_p4.Text = "0";
            textBox_p5.Text = "0";
            textBox_strMessage.Text = "PLC";
        }

        System.Timers.Timer aTimer = new System.Timers.Timer();

        byte[] res = new byte[68];

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //Thread thread1 = new Thread(TimerMange);
            //thread1.IsBackground = true;
            //thread1.Start();
        }

        void TimerMange()
        {
            //aTimer.Elapsed += new ElapsedEventHandler(socket_rev);    //定时事件的方法
            //aTimer.Interval = 100;
            while (true)
            {
                socket_rev(null,null);
            }
        }

        private string parse(byte[] buff)
        {
            int offset = 0;
            string channelId = BitConverter.ToInt32(buff, offset).ToString(); ;offset += 4;
            string msgType = BitConverter.ToInt32(buff, offset).ToString(); offset += 4;
            string commandId = BitConverter.ToInt32(buff, offset).ToString(); offset += 4;
            string param1 = BitConverter.ToSingle(buff, offset).ToString(); offset += 4;
            string param2 = BitConverter.ToSingle(buff, offset).ToString(); offset += 4;
            string param3 = BitConverter.ToSingle(buff, offset).ToString(); offset += 4;
            string param4 = BitConverter.ToSingle(buff, offset).ToString(); offset += 4;
            string param5 = BitConverter.ToSingle(buff, offset).ToString(); offset += 8;
            string errorcode = BitConverter.ToInt64(buff, offset).ToString();
            string strMessage = "0";

            string dataStr = channelId + " " + msgType + " " + commandId + " " + param1 + " " + param2 + " " + param3 + " " + param4 + " " + param5 + " " + errorcode + " " + strMessage;
            return dataStr;
        }
        string flagStr = null;
        private void socket_rev(object sender, EventArgs e)
        {
            try
            {
                //int receiveLength = clientSocket.Receive(res, res.Length, SocketFlags.None);
                int receiveLength = clientSocket.Receive(res);
                if (receiveLength > 0)
                {
                    string dataStr = null;
                    dataStr = parse(res);
                    string str = string.Format("{0} recieve data: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm;ssss"), dataStr);
                    if (string.Compare(flagStr,str)!=0)
                    {
                        textBox1.AppendText(str + "\r\n");
                        textBox1.AppendText("\r\n");
                        flagStr = str;
                    }
                    
                }
                else if (receiveLength==0)
                {
                    //dicconnect
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SendCmd(int cmd, int stationID = 1)
        {
            PLCData plcData = new PLCData()
            {

                channelId = int.Parse(tb_channalId.Text),
                msgType = int.Parse(tb_msgType.Text),
                commandId = cmd,
                param1 = stationID,
                param2 = float.Parse(textBox_p2.Text),
                param3 = float.Parse(textBox_p3.Text),
                param4 = float.Parse(textBox_p4.Text),
                param5 = float.Parse(textBox_p5.Text),
                errorcode = long.Parse(textBox_errcode.Text),
                strMessage = textBox_strMessage.Text.ToString()

            };

            string dataStr = plcData.channelId + " " + plcData.msgType + " " + plcData.commandId + " " + plcData.param1 + " " + plcData.param2 + " " + plcData.param3 + " " + plcData.param4 + " " + plcData.param5 + " " + plcData.errorcode + " " + plcData.strMessage;
            string str = string.Format("{0} send cmd: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm;ssss"), dataStr);
            textBox1.AppendText(str + "\r\n");

            byte[] sendbuf = Form1.PLCDataToByte(plcData);
            clientSocket.Send(sendbuf);
        }

        int n = 0;
        bool flag = true;
        private void start()
        {
            while (flag)
            {

                SendCmd(startCmd, 1);
                Thread.Sleep(5000);
                SendCmd(startCmd, 2);
                Thread.Sleep(5000);
                SendCmd(startCmd, 3);
                Thread.Sleep(5000);
                n++;
                if (10000 == n) break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            Thread th = new Thread(start);
            th.IsBackground = true;
            th.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendCmd(1, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendCmd(startCmd, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendCmd(startCmd, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendCmd(startCmd, 3);
        }
    }
}
