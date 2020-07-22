using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChartControlTest
{
    public partial class Form1 : Form
    {
        private Queue<double> dataQueue = new Queue<double>(100);

        private int curValue = 0;

        private int num = 10;//每次删除增加几个点
        public Form1()
        {
            InitializeComponent();
            Tip(this.button1, "打开定时器");
            Tip(this.button2, "关闭定时器");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();
            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }

        private void UpdateQueueValue()
        {

            if (dataQueue.Count > 200)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
                
            }
            for (int i = 0; i < num; i++)
            {
                //对curValue只取[0,360]之间的值
                curValue = curValue % 360;
                //对得到的正玄值，放大50倍，并上移50
                dataQueue.Enqueue((100 * Math.Sin(curValue * Math.PI / 180)));
                curValue = curValue + 10;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Tip(Control obj,string msg)
        {
           
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 500;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(obj, msg);
        }

    }
}
