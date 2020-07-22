namespace ProgressTest {
	partial class DualTests {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DualTests));
			this.button1 = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.dualProgressBar1 = new ProgressODoom.DualProgressBar();
			this.dualPlainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
			this.dualRoundGlossPainter1 = new ProgressODoom.RoundGlossPainter();
			this.dualPlainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
			this.dualPlainProgressPainter2 = new ProgressODoom.PlainProgressPainter();
			this.dualRoundGlossPainter2 = new ProgressODoom.RoundGlossPainter();
			this.dualPlainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
			this.dualGradientGlossPainter1 = new ProgressODoom.GradientGlossPainter();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 111);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 22);
			this.button1.TabIndex = 8;
			this.button1.Text = "Test Run";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(3, 30);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(209, 42);
			this.trackBar1.TabIndex = 14;
			this.trackBar1.TickFrequency = 10;
			this.trackBar1.Value = 36;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.Location = new System.Drawing.Point(3, 63);
			this.trackBar2.Maximum = 100;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(209, 42);
			this.trackBar2.TabIndex = 15;
			this.trackBar2.TickFrequency = 10;
			this.trackBar2.Value = 56;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// dualProgressBar1
			// 
			this.dualProgressBar1.BackgroundPainter = this.dualPlainBackgroundPainter1;
			this.dualProgressBar1.BorderPainter = this.dualPlainBorderPainter1;
			this.dualProgressBar1.Location = new System.Drawing.Point(10, 12);
			this.dualProgressBar1.MasterMaximum = 100;
			this.dualProgressBar1.MasterPainter = this.dualPlainProgressPainter2;
			this.dualProgressBar1.MasterProgressPadding = 0;
			this.dualProgressBar1.MasterValue = 56;
			this.dualProgressBar1.Maximum = 100;
			this.dualProgressBar1.Minimum = 0;
			this.dualProgressBar1.Name = "dualProgressBar1";
			this.dualProgressBar1.PaintMasterFirst = true;
			this.dualProgressBar1.ProgressPadding = 2;
			this.dualProgressBar1.ProgressPainter = this.dualPlainProgressPainter1;
			this.dualProgressBar1.ShowPercentage = false;
			this.dualProgressBar1.Size = new System.Drawing.Size(194, 12);
			this.dualProgressBar1.TabIndex = 7;
			this.dualProgressBar1.Value = 36;
			// 
			// dualPlainBackgroundPainter1
			// 
			this.dualPlainBackgroundPainter1.Color = System.Drawing.Color.White;
			this.dualPlainBackgroundPainter1.GlossPainter = this.dualRoundGlossPainter1;
			// 
			// dualRoundGlossPainter1
			// 
			this.dualRoundGlossPainter1.AlphaHigh = 255;
			this.dualRoundGlossPainter1.AlphaLow = 0;
			this.dualRoundGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
			this.dualRoundGlossPainter1.Style = ProgressODoom.GlossStyle.Top;
			this.dualRoundGlossPainter1.Successor = null;
			this.dualRoundGlossPainter1.TaperHeight = 3;
			// 
			// dualPlainBorderPainter1
			// 
			this.dualPlainBorderPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.dualPlainBorderPainter1.RoundedCorners = true;
			this.dualPlainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
			// 
			// dualPlainProgressPainter2
			// 
			this.dualPlainProgressPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(229)))), ((int)(((byte)(124)))));
			this.dualPlainProgressPainter2.GlossPainter = this.dualRoundGlossPainter2;
			this.dualPlainProgressPainter2.LeadingEdge = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(203)))), ((int)(((byte)(111)))));
			this.dualPlainProgressPainter2.ProgressBorderPainter = null;
			// 
			// dualRoundGlossPainter2
			// 
			this.dualRoundGlossPainter2.AlphaHigh = 255;
			this.dualRoundGlossPainter2.AlphaLow = 0;
			this.dualRoundGlossPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(191)))), ((int)(((byte)(104)))));
			this.dualRoundGlossPainter2.Style = ProgressODoom.GlossStyle.Top;
			this.dualRoundGlossPainter2.Successor = null;
			this.dualRoundGlossPainter2.TaperHeight = 3;
			// 
			// dualPlainProgressPainter1
			// 
			this.dualPlainProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
			this.dualPlainProgressPainter1.GlossPainter = this.dualGradientGlossPainter1;
			this.dualPlainProgressPainter1.LeadingEdge = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
			this.dualPlainProgressPainter1.ProgressBorderPainter = this.dualPlainBorderPainter1;
			// 
			// dualGradientGlossPainter1
			// 
			this.dualGradientGlossPainter1.AlphaHigh = 240;
			this.dualGradientGlossPainter1.AlphaLow = 0;
			this.dualGradientGlossPainter1.Angle = 90F;
			this.dualGradientGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(233)))), ((int)(((byte)(143)))));
			this.dualGradientGlossPainter1.PercentageCovered = 90;
			this.dualGradientGlossPainter1.Style = ProgressODoom.GlossStyle.Top;
			this.dualGradientGlossPainter1.Successor = null;
			// 
			// DualTests
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(216, 138);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dualProgressBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DualTests";
			this.Text = "Dual Progress Bars";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ProgressODoom.RoundGlossPainter dualRoundGlossPainter2;
		private ProgressODoom.DualProgressBar dualProgressBar1;
		private ProgressODoom.PlainBackgroundPainter dualPlainBackgroundPainter1;
		private ProgressODoom.RoundGlossPainter dualRoundGlossPainter1;
		private ProgressODoom.PlainBorderPainter dualPlainBorderPainter1;
		private ProgressODoom.PlainProgressPainter dualPlainProgressPainter2;
		private ProgressODoom.PlainProgressPainter dualPlainProgressPainter1;
		private ProgressODoom.GradientGlossPainter dualGradientGlossPainter1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
	}
}