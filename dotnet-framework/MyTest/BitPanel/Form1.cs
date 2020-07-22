using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BitPanel.UserControls;
using BitPanel.Forms;

namespace BitPanel
{
    public partial class Form1 : Form
    {
        int row = 0;
        int col = 0;
        int remain = 0;
        int offsetX = 20;
        int offsetY = 10;       

        ConfigForm CF;
        List<BitForm> bfList = new List<BitForm>();
        public Form1()
        {
            InitializeComponent();
            InitConfigForm();
            InitBitPanel();
        }
        private void InitConfigForm()
        {
            CF = new ConfigForm();
            CF.ConfigClick_Evt += CF_ConfigClick_Evt;
        }
        private void CF_ConfigClick_Evt()
        {
            InitBitPanel();
        }
        private void InitBitPanel()
        {
            this.panel1.Controls.Clear();
            this.bfList.Clear();

            int count = 0;
            BitForm temp = new BitForm();
            row = CF.BitCount / 10;
            remain = CF.BitCount % 10;
            if (remain!=0)
            {
                row = row + 1;
            }
            if (CF.BitCount < 10)
            {
                row = 1;
                col = 1;
                this.Size = new Size(10 * temp.Width+ offsetX, 3 * temp.Height+ offsetY);
            }
            for (int i = 0; i < row; i++)
            {
                if (i==row-1)
                {
                    for (int k = 0; k < remain; k++)
                    {
                        count++;
                        DrawBitPanel(count,i,k);
                    }
                }
                else
                {
                    for (int j = 0; j < 10; j++)
                    {
                        count++;
                        DrawBitPanel(count,i,j);
                    }
                }
            }
            this.Size = new Size(10 * temp.Width+offsetX, (row+2) * temp.Height+offsetY);
        }
        private void DrawBitPanel(int count,int i,int j)
        {
            BitForm bf = new BitForm("B" + count.ToString());
            bf.BitClick_Evt += Bf_BitClick_Evt;
            bf.SetBKColor(Color.Gray);
            bf.SetTag(count - 1);
            bf.Location = new Point(j * bf.Width, i * bf.Height);
            this.panel1.Controls.Add(bf);
            bfList.Add(bf);
        }

        private void Bf_BitClick_Evt(object sender)
        {
            Button btn = sender as Button;
            //todo
            Console.WriteLine("send msg");
        }
        private void toolStripLabel_Click(object sender, EventArgs e)
        {
            CF.Show();
            CF.Focus();
        }
    }
}
