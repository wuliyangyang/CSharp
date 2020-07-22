using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgressTest {
	public partial class DualTests : Form {
		public DualTests() {
			InitializeComponent();
		}

		private bool go = false;
		private void button1_Click(object sender, EventArgs e) {
			go = true;
			dualProgressBar1.Value = 0;
			dualProgressBar1.MasterValue = 0;
			dualProgressBar1.Maximum = 2000;
			dualProgressBar1.MasterMaximum = 10000;
			for (int i = 0; i < 5; i++) {
				if (!go) { break; }
				dualProgressBar1.Value = 0;
				for (int j = 0; j < 2000; j++) {
					if (!go) { break; }
					dualProgressBar1.Value = j;
					dualProgressBar1.MasterValue++;
					Application.DoEvents();
				}
			}
			dualProgressBar1.Value = 0;
			dualProgressBar1.MasterValue = 0;
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			go = false;
			dualProgressBar1.Maximum = 100;
			dualProgressBar1.Value = trackBar1.Value;
		}

		private void trackBar2_Scroll(object sender, EventArgs e) {
			go = false;
			dualProgressBar1.MasterMaximum = 100;
			dualProgressBar1.MasterValue = trackBar2.Value;
		}
	}
}