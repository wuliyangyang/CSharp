using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgressTest {
	public partial class MarqueeTest : Form {
		public MarqueeTest() {
			InitializeComponent();
		}

		private void MarqueeTest_Load(object sender, EventArgs e) {
		}

		private void timer1_Tick(object sender, EventArgs e) {
			Random r = new Random(DateTime.Now.Millisecond);
			int newval = progressBarEx1.MasterValue + r.Next(0, 10);
			if (newval > progressBarEx1.MasterMaximum) {
				progressBarEx1.MasterValue = 0;
			} else {
				progressBarEx1.MasterValue = newval;
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			progressBarEx1.MarqueeStart();
			button1.Enabled = false;
			button2.Enabled = true;
			button3.Enabled = true;
			groupBox1.Enabled = false;
			timer1.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e) {
			progressBarEx1.MarqueePause();
			button1.Enabled = true;
			button2.Enabled = false;
			button3.Enabled = true;
			groupBox1.Enabled = false;
			timer1.Enabled = false;
		}

		private void button3_Click(object sender, EventArgs e) {
			progressBarEx1.MarqueeStop();
			button1.Enabled = true;
			button2.Enabled = false;
			button3.Enabled = false;
			groupBox1.Enabled = true;
			timer1.Enabled = false;
			progressBarEx1.MasterValue = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox1.Text.Length == 0) { return; }
			try {
				progressBarEx1.ProgressType = (ProgressODoom.ProgressType)Enum.Parse(typeof(ProgressODoom.ProgressType), comboBox1.Text);
			} catch { }
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			progressBarEx1.MarqueeSpeed = (int)numericUpDown1.Value;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
			progressBarEx1.MarqueePercentage = (int)numericUpDown2.Value;
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e) {
			progressBarEx1.MarqueeStep = (int)numericUpDown3.Value;
		}

		private void button4_Click(object sender, EventArgs e) {
			progressBarEx2.Value = 100;
			progressBarEx2.StartAnimation();
			//stripedProgressPainter1.Animate();
			button4.Enabled = false;
			button5.Enabled = true;
			numericUpDown4.Enabled = false;
			comboBox2.Enabled = false;
		}

		private void button5_Click(object sender, EventArgs e) {
			progressBarEx2.Value = 0;
			progressBarEx2.StopAnimation();
			//stripedProgressPainter1.DeAnimate();
			button4.Enabled = true;
			button5.Enabled = false;
			numericUpDown4.Enabled = true;
			comboBox2.Enabled = true;
		}

		private void numericUpDown4_ValueChanged(object sender, EventArgs e) {
			stripedProgressPainter1.AnimationSpeed = (int)numericUpDown4.Value;
			waveProgressPainter1.AnimationSpeed = (int)numericUpDown4.Value;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			switch (comboBox2.SelectedIndex) {
				case 0: progressBarEx2.ProgressPainter = stripedProgressPainter1; break;
				case 1: progressBarEx2.ProgressPainter = waveProgressPainter1; break;
			}
		}
	}
}