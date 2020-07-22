using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitPanel.Forms
{
    public partial class ConfigForm : Form
    {
        public delegate void NotifyEvt();
        public event NotifyEvt ConfigClick_Evt;
        public int BitCount { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public ConfigForm()
        {
            InitializeComponent();
            BitCount = 64;
            Row = 8;
            Col = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 1;
            bool ret = int.TryParse(textBox1.Text, out count);
            BitCount = count;

            if (this.ConfigClick_Evt!=null)
            {
                this.ConfigClick_Evt();
            }
            this.Hide();
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();          
        }
    }
}
