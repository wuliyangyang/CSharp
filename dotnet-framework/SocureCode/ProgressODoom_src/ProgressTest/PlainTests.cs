using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgressTest {
	public partial class PlainTests : Form {
		// plainProgressPainter's LeadingEdge was "174, 126, 176" before we added padding and the prog's border painter.

		public PlainTests() {
			InitializeComponent();
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			goldProgressBarEx1.Value = trackBar1.Value;
			greenProgressBarEx2.Value = trackBar1.Value;
			orangeProgressBarEx1.Value = trackBar1.Value;
			blueProgressBarEx1.Value = trackBar1.Value;
			progressBarEx1.Value = trackBar1.Value;
			dualProgressBar1.Value = trackBar1.Value;
			rarDualProgressBar1.Value = trackBar1.Value;
			rarProgressBar1.Value = trackBar1.Value;
			youTubeDualProgressBar1.Value = trackBar1.Value;
			int master = trackBar1.Value + 20;
			if (master > 100) {
				master = 100;
			}
			dualProgressBar1.MasterValue = master;
			rarDualProgressBar1.MasterValue = master;
			rarProgressBar1.MasterValue = master;
			youTubeDualProgressBar1.MasterValue = master;
		}
	}
}