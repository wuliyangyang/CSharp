using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgressTest {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private bool go = false;
		private void button1_Click(object sender, EventArgs e) {
			go = true;
			progressBarEx1.Value = 0;
			progressBarEx1.Maximum = 10000;
			for (int i = 0; i < progressBarEx1.Maximum; i++) {
				if (!go) { break; }
				progressBarEx1.Value = i;
				Application.DoEvents();
			}
			//progressBarEx1.Value = 0;
		}

		private void button2_Click(object sender, EventArgs e) {
			go = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			// Plain, Gradient, Fruity Loops, Candy Cane
			switch (comboBox1.SelectedIndex) {
				case 0: progressBarEx1.BackgroundPainter = plainBackgroundPainter1; break;
				case 1: progressBarEx1.BackgroundPainter = gradientBackgroundPainter1; break;
				case 2: progressBarEx1.BackgroundPainter = fruityLoopsBackgroundPainter1; break;
				case 3: progressBarEx1.BackgroundPainter = candyCaneBackgroundPainter1; break;
				case 4: progressBarEx1.BackgroundPainter = rarBackgroundPainter1; break;
			}
			comboBox4.SelectedIndex = 1;
			propertyGrid1.SelectedObject = progressBarEx1.BackgroundPainter;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			// Plain, Barber Pole, Java, Fruity Loops, Metal, Bevel, Candy Cane
			switch (comboBox2.SelectedIndex) {
				case 0: progressBarEx1.ProgressPainter = plainProgressPainter1; break;
				case 1:
					progressBarEx1.ProgressPainter = barberPoleProgressPainter1;
					progressBarEx1.Size = new Size(progressBarEx1.Width + 1, progressBarEx1.Height);
					progressBarEx1.Size = new Size(progressBarEx1.Width - 1, progressBarEx1.Height);
					break;
				case 2: progressBarEx1.ProgressPainter = javaProgressPainter1; break;
				case 3: progressBarEx1.ProgressPainter = fruityLoopsProgressPainter1; break;
				case 4: progressBarEx1.ProgressPainter = metalProgressPainter1; break;
				case 5: progressBarEx1.ProgressPainter = bevelledProgressPainter1; break;
				case 6: progressBarEx1.ProgressPainter = bevelledGradientProgressPainter1; break;
				case 7: progressBarEx1.ProgressPainter = candyCaneProgressPainter1; break;
				case 8: progressBarEx1.ProgressPainter = rarProgressPainter1; break;
			}
			comboBox4.SelectedIndex = 2;
			propertyGrid1.SelectedObject = progressBarEx1.ProgressPainter;
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			// Plain, Styled
			switch (comboBox3.SelectedIndex) {
				case 0: progressBarEx1.BorderPainter = plainBorderPainter1; break;
				case 1: progressBarEx1.BorderPainter = styledBorderPainter1; break;
				case 2: progressBarEx1.BorderPainter = rarBorderPainter1; break;
			}
			comboBox4.SelectedIndex = 0;
			propertyGrid1.SelectedObject = progressBarEx1.BorderPainter;
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
			// Border, Background, Progress
			switch (comboBox4.SelectedIndex) {
				case 0: propertyGrid1.SelectedObject = progressBarEx1.BorderPainter; break;
				case 1: propertyGrid1.SelectedObject = progressBarEx1.BackgroundPainter; break;
				case 2: propertyGrid1.SelectedObject = progressBarEx1.ProgressPainter; break;
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			go = false;
			progressBarEx1.Maximum = 10000;
			progressBarEx1.Value = trackBar1.Value;
		}

		private void progressBarEx1_Click(object sender, EventArgs e) {
			propertyGrid1.SelectedObject = progressBarEx1;
		}

		private void button4_Click(object sender, EventArgs e) {
			PlainTests pt = new PlainTests();
			pt.Show();
		}

		private void button5_Click(object sender, EventArgs e) {
			Glosses gl = new Glosses();
			gl.Show();
		}

		private void button3_Click(object sender, EventArgs e) {
			DualTests dt = new DualTests();
			dt.Show();
		}

		private void button6_Click(object sender, EventArgs e) {
			MarqueeTest mt = new MarqueeTest();
			mt.Show();
		}
	}
}