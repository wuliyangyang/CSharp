using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slider
{
    public partial class Form1 : Form
    {
        private bool flag = true;
        public Form1()
        {
            InitializeComponent();
        }

        void pShowD()
        {
            //当前滑块的位置
            double d = 0;
            //true/false：向右滑/向左滑
            bool bToRight = true;
            //时间间隔，单位：ms
            int iInterval = 10;
            //从左到右所需要的总时间，单位：ms
            int iAnimateTime = 2000;
            //移动距离要减去滑块本身的宽度
            double dMoveDistance = panel_Board.Width - panel_Slider.Width;
            //需要变化的次数
            double dStep = Convert.ToDouble(iAnimateTime) / iInterval;
            //每次变化所增加的距离
            double dPerX = dMoveDistance / dStep;
            while (flag)
            {
                d = bToRight ? d + dPerX : d - dPerX;
                if (d > dMoveDistance)
                {
                    bToRight = false;
                }
                if (d < 0)
                {
                    bToRight = true;
                }
                Thread.Sleep(iInterval);
                int iZ = Convert.ToInt32(d);
                pSetLeft(iZ);
            }
        }
        void pSetLeft(int i)
        {
            if (panel_Slider.InvokeRequired)
            {
                panel_Slider.Invoke(new Action<int>(pSetLeft), new object[] { i });
            }
            else
            {
                panel_Slider.Left = i;
            }
        }

        /// <summary>
        /// 开始演示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            Task.Run(() => { pShowD(); });
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
        }
    }
}
