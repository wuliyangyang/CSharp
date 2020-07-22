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

namespace 八皇后
{
    public partial class List : Form
    {
        public List<int[]> queenPostList { get; set; }
        public PictureBox[] Pb { get; set; }

        private Image image = Image.FromFile("queen.jpg");

        public Form f { get; set; }

        private bool IsStop = false;

        public MenuStrip MS { get; set; }

        public PictureBox[] tempPb;
        public int sum { get; set; }

        private int index = 0;
        public List()
        {
            InitializeComponent();
            this.TopMost = false;
            this.BringToFront();
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NextOrPre("0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NextOrPre("1");
        }

        public void NextOrPre(string s)
        {
            switch (s)
            {
                case "0":
                    index = comboBox1.SelectedIndex;
                    index++;
                    if (index > sum - 1) index = 0;
                    comboBox1.SelectedIndex = index;
                    Console.WriteLine(index);
                    GetResult(index);
                    break;
                case "1":

                    index = comboBox1.SelectedIndex;
                    index--;
                    if (index < 0) index = sum - 1;

                    comboBox1.SelectedIndex = index;
                    Console.WriteLine(index);
                    GetResult(index);
                    break;
                default:
                    break;
            }
        }

        private void List_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < queenPostList.Count; i++)
            {
                comboBox1.Items.Add(i);
            }
            tempPb = Pb;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th;
            if (button3.Text == "自动播放")
            {
                th = new Thread(AutoPlay);
                th.IsBackground = true;
                th.Start();

                this.Invoke(new Action(() =>
                {
                    button3.Text = "停止";
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    button3.Text = "自动播放";
                    IsStop = true;
                }));
            }
            
        }

        public void AutoPlay()
        {
            int index = 0;
            while (!IsStop)
            {
                this.Invoke(new Action(() =>
                {
                    GetResult(index);
                }));
                
                index++;
                Thread.Sleep(1000);
            }
        }

        public void GetResult(int index)
        {
            ClearPic();
            int[] postList = queenPostList[index];
            for (int i = 0; i < 8; i++)
            {
                int x = (postList[i] - 1)+(8*i);
                Pb[x].Image = image;
            }
        }

        public void ClearPic()
        {
            for (int i = 0; i < Pb.Length; i++)
            {
                Pb[i].Image = null;
            }
        }

        public new void Close()
        {
            this.Dispose();
        }

        private void List_FormClosed(object sender, FormClosedEventArgs e)
        {
            MS.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetResult(comboBox1.SelectedIndex);
        }
    }
}
