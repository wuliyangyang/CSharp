using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitPanel.UserControls
{
    public partial class BitForm : UserControl
    {
        public delegate void BitClick(object sender);
        public event BitClick BitClick_Evt;
        public string UIName { get; set; }

        public BitForm()
        {
            InitializeComponent();
        }
        public BitForm(string UIName)
        {
            InitializeComponent();
            this.UIName = UIName;
            SetUIName();
        }
        public void SetBKColor(Color c)
        {
            button.BackColor = c;
        }
        public void SetTag(int tag)
        {
            button.Tag = tag;
        }
        private void SetUIName()
        {
            button.Text = this.UIName;
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (this.BitClick_Evt!=null)
            {
                this.BitClick_Evt(sender);
            }
        }
    }
}
