using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogToolLib;

namespace LogTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Log.LogInfo("Init Form");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogToolLib.Log.LogInfo("log Info");
            LogToolLib.Log.LogDebug("log debug");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogToolLib.Log.LogError("log error");
            LogToolLib.Log.LogWarn("log warn");
        }
    }
}
