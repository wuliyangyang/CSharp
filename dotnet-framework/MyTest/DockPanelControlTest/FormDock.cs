using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;

namespace DockPanelControlTest
{
    public partial class FormDock : DockContent
    {
        public TextBoxBase TextBox { get; set; }
        public FormDock()
        {
            InitializeComponent();
            //this.CloseButtonVisible = false;
            this.TextBox = logtextBox;
        }

        private void FormDock_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void FormDock_MouseLeave(object sender, EventArgs e)
        {

        }

        private void FormDock_Shown(object sender, EventArgs e)
        {

        }

        private void FormDock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormDock_DockStateChanged(object sender, EventArgs e)
        {

        }
    }
}
