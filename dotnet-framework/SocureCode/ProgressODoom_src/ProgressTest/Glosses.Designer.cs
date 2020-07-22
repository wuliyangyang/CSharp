namespace ProgressTest {
	partial class Glosses {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glosses));
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.progressBarEx1 = new ProgressODoom.ProgressBarEx();
			this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
			this.roundGlossPainter1 = new ProgressODoom.RoundGlossPainter();
			this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
			this.plainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
			this.gradientGlossPainter1 = new ProgressODoom.GradientGlossPainter();
			this.flatGlossPainter1 = new ProgressODoom.FlatGlossPainter();
			this.middleGlossPainter1 = new ProgressODoom.MiddleGlossPainter();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(1, 34);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(196, 42);
			this.trackBar1.TabIndex = 13;
			this.trackBar1.TickFrequency = 10;
			this.trackBar1.Value = 25;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(207, 12);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(222, 221);
			this.propertyGrid1.TabIndex = 14;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(1, 82);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 109);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Object";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 21);
			this.label3.TabIndex = 5;
			this.label3.Text = "Border";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "None",
            "Master Border"});
			this.comboBox3.Location = new System.Drawing.Point(56, 73);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(138, 21);
			this.comboBox3.TabIndex = 4;
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Gloss";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "Object";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Flat",
            "Gradient",
            "Middle",
            "Round"});
			this.comboBox2.Location = new System.Drawing.Point(56, 46);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(138, 21);
			this.comboBox2.TabIndex = 1;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Progress",
            "Background"});
			this.comboBox1.Location = new System.Drawing.Point(56, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(138, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// progressBarEx1
			// 
			this.progressBarEx1.BackgroundPainter = this.plainBackgroundPainter1;
			this.progressBarEx1.BorderPainter = this.plainBorderPainter1;
			this.progressBarEx1.Location = new System.Drawing.Point(9, 12);
			this.progressBarEx1.Maximum = 100;
			this.progressBarEx1.Minimum = 0;
			this.progressBarEx1.Name = "progressBarEx1";
			this.progressBarEx1.ProgressPadding = 0;
			this.progressBarEx1.ProgressPainter = this.plainProgressPainter1;
			this.progressBarEx1.ShowPercentage = false;
			this.progressBarEx1.Size = new System.Drawing.Size(180, 16);
			this.progressBarEx1.TabIndex = 0;
			this.progressBarEx1.Value = 25;
			this.progressBarEx1.Click += new System.EventHandler(this.progressBarEx1_Click);
			// 
			// plainBackgroundPainter1
			// 
			this.plainBackgroundPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(208)))));
			this.plainBackgroundPainter1.GlossPainter = this.roundGlossPainter1;
			// 
			// roundGlossPainter1
			// 
			this.roundGlossPainter1.AlphaHigh = 240;
			this.roundGlossPainter1.AlphaLow = 0;
			this.roundGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
			this.roundGlossPainter1.Style = ProgressODoom.GlossStyle.Both;
			this.roundGlossPainter1.Successor = null;
			this.roundGlossPainter1.TaperHeight = 8;
			// 
			// plainBorderPainter1
			// 
			this.plainBorderPainter1.Color = System.Drawing.Color.Olive;
			this.plainBorderPainter1.RoundedCorners = true;
			this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
			// 
			// plainProgressPainter1
			// 
			this.plainProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.plainProgressPainter1.GlossPainter = this.gradientGlossPainter1;
			this.plainProgressPainter1.LeadingEdge = System.Drawing.Color.Transparent;
			this.plainProgressPainter1.ProgressBorderPainter = this.plainBorderPainter1;
			// 
			// gradientGlossPainter1
			// 
			this.gradientGlossPainter1.AlphaHigh = 240;
			this.gradientGlossPainter1.AlphaLow = 0;
			this.gradientGlossPainter1.Angle = 90F;
			this.gradientGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.gradientGlossPainter1.PercentageCovered = 50;
			this.gradientGlossPainter1.Style = ProgressODoom.GlossStyle.Top;
			this.gradientGlossPainter1.Successor = null;
			// 
			// flatGlossPainter1
			// 
			this.flatGlossPainter1.Alpha = 128;
			this.flatGlossPainter1.Color = System.Drawing.Color.White;
			this.flatGlossPainter1.PercentageCovered = 50;
			this.flatGlossPainter1.Style = ProgressODoom.GlossStyle.Bottom;
			this.flatGlossPainter1.Successor = null;
			// 
			// middleGlossPainter1
			// 
			this.middleGlossPainter1.AlphaHigh = 240;
			this.middleGlossPainter1.AlphaLow = 0;
			this.middleGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.middleGlossPainter1.Style = ProgressODoom.GlossStyle.Both;
			this.middleGlossPainter1.Successor = null;
			this.middleGlossPainter1.TaperHeight = 6;
			// 
			// Glosses
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 235);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.progressBarEx1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Glosses";
			this.Text = "Glosses";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ProgressODoom.ProgressBarEx progressBarEx1;
		private System.Windows.Forms.TrackBar trackBar1;
		private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
		private ProgressODoom.PlainBorderPainter plainBorderPainter1;
		private ProgressODoom.PlainProgressPainter plainProgressPainter1;
		private ProgressODoom.RoundGlossPainter roundGlossPainter1;
		private ProgressODoom.FlatGlossPainter flatGlossPainter1;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter1;
		private ProgressODoom.MiddleGlossPainter middleGlossPainter1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox3;
	}
}