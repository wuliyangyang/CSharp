using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProgressODoom;

namespace ProgressTest {
	public partial class Glosses : Form {
		private EventHandler ceh;

		public Glosses() {
			InitializeComponent();
			this.ceh = new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			this.comboBox2.SelectedIndexChanged += this.ceh;
			comboBox1.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			progressBarEx1.Value = trackBar1.Value;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			IGlossPainter igp = null;
			if (comboBox1.Text.Equals("Progress")) {
				propertyGrid1.SelectedObject = plainProgressPainter1;
				igp = plainProgressPainter1.GlossPainter;
			} else if (comboBox1.Text.Equals("Background")) {
				propertyGrid1.SelectedObject = plainBackgroundPainter1;
				igp = plainBackgroundPainter1.GlossPainter;
			}
			if (igp != null) {
				this.comboBox2.SelectedIndexChanged -= ceh;
				if (igp is FlatGlossPainter) {
					comboBox2.SelectedIndex = 0;
				} else if (igp is GradientGlossPainter) {
					comboBox2.SelectedIndex = 1;
				} else if (igp is MiddleGlossPainter) {
					comboBox2.SelectedIndex = 2;
				} else if (igp is RoundGlossPainter) {
					comboBox2.SelectedIndex = 3;
				}
				this.comboBox2.SelectedIndexChanged += ceh;
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			IGlossPainter igp = null;
			if (comboBox2.Text.Equals("Flat")) {
				igp = flatGlossPainter1;
			} else if (comboBox2.Text.Equals("Gradient")) {
				igp = gradientGlossPainter1;
			} else if (comboBox2.Text.Equals("Middle")) {
				igp = middleGlossPainter1;
			} else if (comboBox2.Text.Equals("Round")) {
				igp = roundGlossPainter1;
			}
			if (igp != null) {
				if (comboBox1.Text.Equals("Progress")) {
					plainProgressPainter1.GlossPainter = igp;
				} else if (comboBox1.Text.Equals("Background")) {
					plainBackgroundPainter1.GlossPainter = igp;
				}
				propertyGrid1.SelectedObject = igp;
			}
		}

		private void progressBarEx1_Click(object sender, EventArgs e) {
			propertyGrid1.SelectedObject = progressBarEx1;
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox3.Text.Equals("None")) {
				plainProgressPainter1.ProgressBorderPainter = null;
			} else {
				plainProgressPainter1.ProgressBorderPainter = plainBorderPainter1;
				propertyGrid1.SelectedObject = plainBorderPainter1;
			}
		}
	}
}