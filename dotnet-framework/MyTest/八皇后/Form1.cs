using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 八皇后
{
    public partial class Form1 : Form
    {
        List controlPanel;

        PictureBox[] Pb = new PictureBox[64];//棋盘 

        List<int[]> queenList = new List<int[]>();

        //定义解的个数
        int sum = 0;
        //定义皇后数组
        int[] Queens = new int[8];
        public Form1()
        {
            InitializeComponent();
            AddPictureBox();
            QueenSort(0);
        }

        //制作8*8的国际象棋棋盘
        private void AddPictureBox()
        {
            int N = 0;
            int SD = 70;
            for (int i = 0; i < 8; i++)//8行
            {
                for (int j = 0; j < 8; j++)//8列
                {
                    N = j + i * 8;
                    Pb[N] = new PictureBox();//从第一列由上而下依次编号0到63,共64个格子
                    Pb[N].Height = SD;//每个格子高度 宽度均为 48
                    Pb[N].Width = SD;
                    Pb[N].Top = i * SD;
                    Pb[N].Left = j * SD;
                    if (i % 2 == j % 2)
                    {
                        Pb[N].BackColor = Color.DarkGray;//灰白间隔效果
                    }
                    else
                    {
                        Pb[N].BackColor = Color.White;
                    }
                    this.Controls.Add(Pb[N]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void QueenSort(int num)
        {
            for (int j = 1; j < 9; j++)
            {
                if (num == 8)
                {
                    sum++;
                    //打印输出
                    Write();
                    break;
                }
                //判断是否冲突
                if (FooConflict(num, j))
                {
                    Queens[num] = j;
                    QueenSort(num + 1);
                }
            }
        }

        /// <summary>
        /// 判断皇后是否和之前所有的皇后冲突
        /// </summary>
        /// <param name="row">已放置完毕无冲突皇后的列数</param>
        /// <param name="queen">新放置的皇后值</param>
        /// <returns>是否冲突</returns>
        public bool FooConflict(int row, int queen)
        {
            if (row == 0)
            {
                return true;
            }
            else
            {
                //循环判断与之前的皇后是否有冲突的
                for (int pionter = 0; pionter < row; pionter++)
                {
                    //如果有，返回false
                    if (!FooCompare(Queens[pionter], row - pionter, queen))
                    {
                        return false;
                    }
                }
                //与之前均无冲突，返回true
                return true;
            }
        }
        /// <summary>
        /// 对比2个皇后是否冲突
        /// </summary>
        /// <param name="i">之前的一个皇后</param>
        /// <param name="row">2个皇后的列数之差</param>
        /// <param name="queen">新放置的皇后</param>
        /// <returns></returns>
        public bool FooCompare(int i, int row, int queen)
        {
            //判断2个皇后是否相等或者相差等于列数之差（即处于正反对角线）
            if ((i == queen) || ((i - queen) == row) || ((queen - i) == row))
            {
                return false;
            }
            return true;
        }
        //打印皇后图案
        public void Write()
        {
            //输出皇后的个数排序
            Console.WriteLine("第{0}个皇后排列:", sum);
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 1; j < 9; j++)
            //    {
            //        if (j == Queens[i])
            //        {
            //            Console.Write("■");
            //        }
            //        else
            //        {
            //            Console.Write("□");
            //        }
            //    }
            //    //换行
            //    Console.Write("\n");
            //}
            int[] temp = new int[8];
            for (int i = 0; i < Queens.Length; i++)
            {
                Console.Write(Queens[i]);
                temp[i] = Queens[i];
            }
            queenList.Add(temp);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controlPanel == null)
            {
                controlPanel = new List();
                controlPanel.queenPostList = queenList;
                controlPanel.sum = sum;
                controlPanel.Pb = Pb;
                controlPanel.MS = menuStrip1;
            }
            controlPanel.Show();
            menuStrip1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                controlPanel.Close();
            }
            catch (Exception)
            {
            }
            
        }
    }
}