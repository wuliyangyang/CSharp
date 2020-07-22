using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook.WinApi;

namespace MouseTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            Console.WriteLine("button1_MouseMove");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            Console.WriteLine("button1_MouseLeave");
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //textBox1.Visible = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            //textBox1.Visible = false;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            Console.WriteLine("panel1_MouseLeave");
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            Console.WriteLine("panel1_MouseMove");
        }
    }
}
