namespace ProgressTest {
	partial class MarqueeTest {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarqueeTest));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.progressBarEx1 = new ProgressODoom.DualProgressBar();
			this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
			this.gradientGlossPainter1 = new ProgressODoom.GradientGlossPainter();
			this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
			this.plainProgressPainter2 = new ProgressODoom.PlainProgressPainter();
			this.plainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
			this.roundGlossPainter1 = new ProgressODoom.RoundGlossPainter();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.progressBarEx2 = new ProgressODoom.ProgressBarEx();
			this.stripedProgressPainter1 = new ProgressODoom.StripedProgressPainter();
			this.roundGlossPainter2 = new ProgressODoom.RoundGlossPainter();
			this.waveProgressPainter1 = new ProgressODoom.WaveProgressPainter();
			this.metalProgressPainter1 = new ProgressODoom.MetalProgressPainter();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(7, 49);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 22);
			this.button1.TabIndex = 1;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(7, 77);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 22);
			this.button2.TabIndex = 2;
			this.button2.Text = "Pause";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(7, 105);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 22);
			this.button3.TabIndex = 3;
			this.button3.Text = "Stop";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "MarqueeWrap",
            "MarqueeBounce",
            "MarqueeBounceDeep"});
			this.comboBox1.Location = new System.Drawing.Point(6, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(128, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.Text = "MarqueeBounce";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(88, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(142, 126);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Marquee Properties";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(56, 96);
			this.numericUpDown3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(78, 20);
			this.numericUpDown3.TabIndex = 10;
			this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Step Size";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(56, 70);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(78, 20);
			this.numericUpDown2.TabIndex = 8;
			this.numericUpDown2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Percent";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(56, 46);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
			this.numericUpDown1.TabIndex = 6;
			this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Speed";
			// 
			// timer1
			// 
			this.timer1.Interval = 300;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.progressBarEx1);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Location = new System.Drawing.Point(4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(236, 175);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Marquee";
			// 
			// progressBarEx1
			// 
			this.progressBarEx1.BackgroundPainter = this.plainBackgroundPainter1;
			this.progressBarEx1.BorderPainter = this.plainBorderPainter1;
			this.progressBarEx1.Location = new System.Drawing.Point(6, 19);
			this.progressBarEx1.MarqueePercentage = 25;
			this.progressBarEx1.MarqueeSpeed = 10;
			this.progressBarEx1.MarqueeStep = 2;
			this.progressBarEx1.MasterMaximum = 100;
			this.progressBarEx1.MasterPainter = this.plainProgressPainter2;
			this.progressBarEx1.MasterProgressPadding = 0;
			this.progressBarEx1.MasterValue = 0;
			this.progressBarEx1.Maximum = 100;
			this.progressBarEx1.Minimum = 0;
			this.progressBarEx1.Name = "progressBarEx1";
			this.progressBarEx1.PaintMasterFirst = true;
			this.progressBarEx1.ProgressPadding = 2;
			this.progressBarEx1.ProgressPainter = this.plainProgressPainter1;
			this.progressBarEx1.ProgressType = ProgressODoom.ProgressType.MarqueeBounce;
			this.progressBarEx1.ShowPercentage = false;
			this.progressBarEx1.Size = new System.Drawing.Size(224, 16);
			this.progressBarEx1.TabIndex = 0;
			this.progressBarEx1.Value = 0;
			// 
			// plainBackgroundPainter1
			// 
			this.plainBackgroundPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.plainBackgroundPainter1.GlossPainter = this.gradientGlossPainter1;
			// 
			// gradientGlossPainter1
			// 
			this.gradientGlossPainter1.AlphaHigh = 240;
			this.gradientGlossPainter1.AlphaLow = 0;
			this.gradientGlossPainter1.Angle = 90F;
			this.gradientGlossPainter1.Color = System.Drawing.Color.White;
			this.gradientGlossPainter1.PercentageCovered = 50;
			this.gradientGlossPainter1.Style = ProgressODoom.GlossStyle.Top;
			this.gradientGlossPainter1.Successor = null;
			// 
			// plainBorderPainter1
			// 
			this.plainBorderPainter1.Color = System.Drawing.Color.Black;
			this.plainBorderPainter1.RoundedCorners = true;
			this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
			// 
			// plainProgressPainter2
			// 
			this.plainProgressPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.plainProgressPainter2.GlossPainter = this.gradientGlossPainter1;
			this.plainProgressPainter2.LeadingEdge = System.Drawing.Color.Transparent;
			this.plainProgressPainter2.ProgressBorderPainter = null;
			// 
			// plainProgressPainter1
			// 
			this.plainProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.plainProgressPainter1.GlossPainter = this.roundGlossPainter1;
			this.plainProgressPainter1.LeadingEdge = System.Drawing.Color.Transparent;
			this.plainProgressPainter1.ProgressBorderPainter = this.plainBorderPainter1;
			// 
			// roundGlossPainter1
			// 
			this.roundGlossPainter1.AlphaHigh = 240;
			this.roundGlossPainter1.AlphaLow = 0;
			this.roundGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.roundGlossPainter1.Style = ProgressODoom.GlossStyle.Both;
			this.roundGlossPainter1.Successor = null;
			this.roundGlossPainter1.TaperHeight = 4;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.comboBox2);
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.button5);
			this.groupBox3.Controls.Add(this.numericUpDown4);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.progressBarEx2);
			this.groupBox3.Location = new System.Drawing.Point(4, 185);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(236, 100);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Animated Progress";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(94, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Type";
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Stripe",
            "Wave"});
			this.comboBox2.Location = new System.Drawing.Point(135, 65);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(94, 21);
			this.comboBox2.TabIndex = 11;
			this.comboBox2.Text = "Stripe";
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(7, 41);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 22);
			this.button4.TabIndex = 9;
			this.button4.Text = "Start";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Enabled = false;
			this.button5.Location = new System.Drawing.Point(7, 69);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 22);
			this.button5.TabIndex = 10;
			this.button5.Text = "Stop";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(135, 41);
			this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(95, 20);
			this.numericUpDown4.TabIndex = 8;
			this.numericUpDown4.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(91, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Speed";
			// 
			// progressBarEx2
			// 
			this.progressBarEx2.BackgroundPainter = this.plainBackgroundPainter1;
			this.progressBarEx2.BorderPainter = this.plainBorderPainter1;
			this.progressBarEx2.Location = new System.Drawing.Point(7, 19);
			this.progressBarEx2.MarqueePercentage = 25;
			this.progressBarEx2.MarqueeSpeed = 10;
			this.progressBarEx2.MarqueeStep = 1;
			this.progressBarEx2.Maximum = 100;
			this.progressBarEx2.Minimum = 0;
			this.progressBarEx2.Name = "progressBarEx2";
			this.progressBarEx2.ProgressPadding = 0;
			this.progressBarEx2.ProgressPainter = this.stripedProgressPainter1;
			this.progressBarEx2.ProgressType = ProgressODoom.ProgressType.Smooth;
			this.progressBarEx2.ShowPercentage = false;
			this.progressBarEx2.Size = new System.Drawing.Size(222, 16);
			this.progressBarEx2.TabIndex = 0;
			this.progressBarEx2.Value = 36;
			// 
			// stripedProgressPainter1
			// 
			this.stripedProgressPainter1.Animating = false;
			this.stripedProgressPainter1.AnimationSpeed = 10;
			this.stripedProgressPainter1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.stripedProgressPainter1.GlossPainter = this.roundGlossPainter2;
			this.stripedProgressPainter1.ProgressBorderPainter = null;
			this.stripedProgressPainter1.StripeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.stripedProgressPainter1.StripeSpacing = 0;
			// 
			// roundGlossPainter2
			// 
			this.roundGlossPainter2.AlphaHigh = 150;
			this.roundGlossPainter2.AlphaLow = 0;
			this.roundGlossPainter2.Color = System.Drawing.Color.Maroon;
			this.roundGlossPainter2.Style = ProgressODoom.GlossStyle.Bottom;
			this.roundGlossPainter2.Successor = this.gradientGlossPainter1;
			this.roundGlossPainter2.TaperHeight = 6;
			// 
			// waveProgressPainter1
			// 
			this.waveProgressPainter1.Animating = false;
			this.waveProgressPainter1.AnimationSpeed = 10;
			this.waveProgressPainter1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.waveProgressPainter1.GlossPainter = this.roundGlossPainter2;
			this.waveProgressPainter1.ProgressBorderPainter = null;
			this.waveProgressPainter1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			// 
			// metalProgressPainter1
			// 
			this.metalProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.metalProgressPainter1.GlossPainter = null;
			this.metalProgressPainter1.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.metalProgressPainter1.ProgressBorderPainter = this.plainBorderPainter1;
			// 
			// MarqueeTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(244, 289);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MarqueeTest";
			this.Text = "Marquee Tests";
			this.Load += new System.EventHandler(this.MarqueeTest_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ProgressODoom.DualProgressBar progressBarEx1;
		private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
		private ProgressODoom.PlainBorderPainter plainBorderPainter1;
		private ProgressODoom.PlainProgressPainter plainProgressPainter1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private ProgressODoom.RoundGlossPainter roundGlossPainter1;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Label label3;
		private ProgressODoom.MetalProgressPainter metalProgressPainter1;
		private ProgressODoom.PlainProgressPainter plainProgressPainter2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private ProgressODoom.ProgressBarEx progressBarEx2;
		private ProgressODoom.StripedProgressPainter stripedProgressPainter1;
		private ProgressODoom.RoundGlossPainter roundGlossPainter2;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private ProgressODoom.WaveProgressPainter waveProgressPainter1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox2;
	}
}