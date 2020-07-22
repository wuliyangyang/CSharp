namespace ProgressTest {
	partial class Form1 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.button4 = new System.Windows.Forms.Button();
			this.gradientBackgroundPainter1 = new ProgressODoom.GradientBackgroundPainter();
			this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
			this.plainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
			this.gradientGlossPainter1 = new ProgressODoom.GradientGlossPainter();
			this.gradientGlossPainter2 = new ProgressODoom.GradientGlossPainter();
			this.candyCaneProgressPainter1 = new ProgressODoom.CandyCaneProgressPainter();
			this.gradientGlossPainter3 = new ProgressODoom.GradientGlossPainter();
			this.progressBarEx1 = new ProgressODoom.ProgressBarEx();
			this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
			this.gradientGlossPainter4 = new ProgressODoom.GradientGlossPainter();
			this.metalProgressPainter1 = new ProgressODoom.MetalProgressPainter();
			this.flatGlossPainter1 = new ProgressODoom.FlatGlossPainter();
			this.middleGlossPainter1 = new ProgressODoom.MiddleGlossPainter();
			this.roundGlossPainter1 = new ProgressODoom.RoundGlossPainter();
			this.roundGlossPainter2 = new ProgressODoom.RoundGlossPainter();
			this.styledBorderPainter1 = new ProgressODoom.StyledBorderPainter();
			this.barberPoleProgressPainter1 = new ProgressODoom.BarberPoleProgressPainter();
			this.fruityLoopsBackgroundPainter1 = new ProgressODoom.FruityLoopsBackgroundPainter();
			this.fruityLoopsProgressPainter1 = new ProgressODoom.FruityLoopsProgressPainter();
			this.javaProgressPainter1 = new ProgressODoom.JavaProgressPainter();
			this.bevelledProgressPainter1 = new ProgressODoom.BevelledProgressPainter();
			this.bevelledGradientProgressPainter1 = new ProgressODoom.BevelledGradientProgressPainter();
			this.candyCaneBackgroundPainter1 = new ProgressODoom.CandyCaneBackgroundPainter();
			this.rarBackgroundPainter1 = new ProgressODoom.RarBackgroundPainter();
			this.rarBorderPainter1 = new ProgressODoom.RarBorderPainter();
			this.rarProgressPainter1 = new ProgressODoom.RarProgressPainter();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 76);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(81, 22);
			this.button1.TabIndex = 1;
			this.button1.Text = "GO";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Background Painter";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Plain",
            "Gradient",
            "Fruity Loops",
            "Candy Cane",
            "WinRar"});
			this.comboBox1.Location = new System.Drawing.Point(9, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.Text = "Plain";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Plain",
            "Barber Pole",
            "Java",
            "Fruity Loops",
            "Metal",
            "Bevel",
            "Bevelled Gradient",
            "Candy Cane",
            "WinRar"});
			this.comboBox2.Location = new System.Drawing.Point(9, 72);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 5;
			this.comboBox2.Text = "Plain";
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Progress Painter";
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "Plain",
            "Styled",
            "WinRar"});
			this.comboBox3.Location = new System.Drawing.Point(9, 112);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 7;
			this.comboBox3.Text = "Plain";
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Border Painter";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(99, 76);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(81, 22);
			this.button2.TabIndex = 8;
			this.button2.Text = "Stop";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Items.AddRange(new object[] {
            "Border",
            "Background",
            "Progress"});
			this.comboBox4.Location = new System.Drawing.Point(219, 12);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(206, 21);
			this.comboBox4.TabIndex = 9;
			this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(219, 39);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(206, 330);
			this.propertyGrid1.TabIndex = 10;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(3, 34);
			this.trackBar1.Maximum = 10000;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(217, 42);
			this.trackBar1.TabIndex = 12;
			this.trackBar1.TickFrequency = 500;
			this.trackBar1.Value = 2500;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 257);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(121, 22);
			this.button4.TabIndex = 15;
			this.button4.Text = "Examples";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// gradientBackgroundPainter1
			// 
			this.gradientBackgroundPainter1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
			this.gradientBackgroundPainter1.GlossPainter = null;
			this.gradientBackgroundPainter1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			// 
			// plainBorderPainter1
			// 
			this.plainBorderPainter1.Color = System.Drawing.Color.Purple;
			this.plainBorderPainter1.RoundedCorners = true;
			this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
			// 
			// plainProgressPainter1
			// 
			this.plainProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.plainProgressPainter1.GlossPainter = this.gradientGlossPainter1;
			this.plainProgressPainter1.LeadingEdge = System.Drawing.Color.Violet;
			this.plainProgressPainter1.ProgressBorderPainter = null;
			// 
			// gradientGlossPainter1
			// 
			this.gradientGlossPainter1.AlphaHigh = 192;
			this.gradientGlossPainter1.AlphaLow = 0;
			this.gradientGlossPainter1.Angle = 90F;
			this.gradientGlossPainter1.Color = System.Drawing.Color.White;
			this.gradientGlossPainter1.PercentageCovered = 55;
			this.gradientGlossPainter1.Style = ProgressODoom.GlossStyle.Top;
			this.gradientGlossPainter1.Successor = this.gradientGlossPainter2;
			// 
			// gradientGlossPainter2
			// 
			this.gradientGlossPainter2.AlphaHigh = 240;
			this.gradientGlossPainter2.AlphaLow = 0;
			this.gradientGlossPainter2.Angle = 90F;
			this.gradientGlossPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(126)))), ((int)(((byte)(35)))));
			this.gradientGlossPainter2.PercentageCovered = 45;
			this.gradientGlossPainter2.Style = ProgressODoom.GlossStyle.Bottom;
			this.gradientGlossPainter2.Successor = null;
			// 
			// candyCaneProgressPainter1
			// 
			this.candyCaneProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(129)))), ((int)(((byte)(222)))));
			this.candyCaneProgressPainter1.GlossPainter = null;
			this.candyCaneProgressPainter1.ProgressBorderPainter = null;
			// 
			// gradientGlossPainter3
			// 
			this.gradientGlossPainter3.AlphaHigh = 240;
			this.gradientGlossPainter3.AlphaLow = 64;
			this.gradientGlossPainter3.Angle = 90F;
			this.gradientGlossPainter3.Color = System.Drawing.Color.White;
			this.gradientGlossPainter3.PercentageCovered = 45;
			this.gradientGlossPainter3.Style = ProgressODoom.GlossStyle.Top;
			this.gradientGlossPainter3.Successor = null;
			// 
			// progressBarEx1
			// 
			this.progressBarEx1.BackgroundPainter = this.plainBackgroundPainter1;
			this.progressBarEx1.BorderPainter = this.plainBorderPainter1;
			this.progressBarEx1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.progressBarEx1.Location = new System.Drawing.Point(12, 12);
			this.progressBarEx1.MarqueePercentage = 25;
			this.progressBarEx1.MarqueeSpeed = 100;
			this.progressBarEx1.Maximum = 100;
			this.progressBarEx1.Minimum = 0;
			this.progressBarEx1.Name = "progressBarEx1";
			this.progressBarEx1.ProgressPadding = 0;
			this.progressBarEx1.ProgressPainter = this.plainProgressPainter1;
			this.progressBarEx1.ProgressType = ProgressODoom.ProgressType.Smooth;
			this.progressBarEx1.ShowPercentage = true;
			this.progressBarEx1.Size = new System.Drawing.Size(201, 16);
			this.progressBarEx1.TabIndex = 0;
			this.progressBarEx1.Text = "25%";
			this.progressBarEx1.Value = 25;
			this.progressBarEx1.Click += new System.EventHandler(this.progressBarEx1_Click);
			// 
			// plainBackgroundPainter1
			// 
			this.plainBackgroundPainter1.Color = System.Drawing.Color.Gainsboro;
			this.plainBackgroundPainter1.GlossPainter = this.gradientGlossPainter3;
			// 
			// gradientGlossPainter4
			// 
			this.gradientGlossPainter4.AlphaHigh = 240;
			this.gradientGlossPainter4.AlphaLow = 0;
			this.gradientGlossPainter4.Angle = 90F;
			this.gradientGlossPainter4.Color = System.Drawing.Color.Silver;
			this.gradientGlossPainter4.PercentageCovered = 45;
			this.gradientGlossPainter4.Style = ProgressODoom.GlossStyle.Bottom;
			this.gradientGlossPainter4.Successor = null;
			// 
			// metalProgressPainter1
			// 
			this.metalProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.metalProgressPainter1.GlossPainter = null;
			this.metalProgressPainter1.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.metalProgressPainter1.ProgressBorderPainter = null;
			// 
			// flatGlossPainter1
			// 
			this.flatGlossPainter1.Alpha = 128;
			this.flatGlossPainter1.Color = System.Drawing.Color.White;
			this.flatGlossPainter1.PercentageCovered = 60;
			this.flatGlossPainter1.Style = ProgressODoom.GlossStyle.Both;
			this.flatGlossPainter1.Successor = null;
			// 
			// middleGlossPainter1
			// 
			this.middleGlossPainter1.AlphaHigh = 192;
			this.middleGlossPainter1.AlphaLow = 0;
			this.middleGlossPainter1.Color = System.Drawing.Color.White;
			this.middleGlossPainter1.Style = ProgressODoom.GlossStyle.Both;
			this.middleGlossPainter1.Successor = null;
			this.middleGlossPainter1.TaperHeight = 8;
			// 
			// roundGlossPainter1
			// 
			this.roundGlossPainter1.AlphaHigh = 255;
			this.roundGlossPainter1.AlphaLow = 0;
			this.roundGlossPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(191)))), ((int)(((byte)(104)))));
			this.roundGlossPainter1.Style = ProgressODoom.GlossStyle.Bottom;
			this.roundGlossPainter1.Successor = this.roundGlossPainter2;
			this.roundGlossPainter1.TaperHeight = 6;
			// 
			// roundGlossPainter2
			// 
			this.roundGlossPainter2.AlphaHigh = 240;
			this.roundGlossPainter2.AlphaLow = 0;
			this.roundGlossPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(255)))), ((int)(((byte)(191)))));
			this.roundGlossPainter2.Style = ProgressODoom.GlossStyle.Top;
			this.roundGlossPainter2.Successor = this.middleGlossPainter1;
			this.roundGlossPainter2.TaperHeight = 6;
			// 
			// styledBorderPainter1
			// 
			this.styledBorderPainter1.Border3D = System.Windows.Forms.Border3DStyle.Flat;
			// 
			// barberPoleProgressPainter1
			// 
			this.barberPoleProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(119)))));
			this.barberPoleProgressPainter1.GlossPainter = null;
			this.barberPoleProgressPainter1.ProgressBorderPainter = null;
			// 
			// fruityLoopsBackgroundPainter1
			// 
			this.fruityLoopsBackgroundPainter1.FruityType = ProgressODoom.FruityLoopsProgressPainter.FruityLoopsProgressType.DoubleLayer;
			this.fruityLoopsBackgroundPainter1.GlossPainter = null;
			// 
			// fruityLoopsProgressPainter1
			// 
			this.fruityLoopsProgressPainter1.FruityType = ProgressODoom.FruityLoopsProgressPainter.FruityLoopsProgressType.DoubleLayer;
			this.fruityLoopsProgressPainter1.GlossPainter = null;
			this.fruityLoopsProgressPainter1.ProgressBorderPainter = null;
			// 
			// javaProgressPainter1
			// 
			this.javaProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(119)))));
			this.javaProgressPainter1.GlossPainter = null;
			this.javaProgressPainter1.ProgressBorderPainter = null;
			// 
			// bevelledProgressPainter1
			// 
			this.bevelledProgressPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(119)))));
			this.bevelledProgressPainter1.GlossPainter = null;
			this.bevelledProgressPainter1.ProgressBorderPainter = null;
			// 
			// bevelledGradientProgressPainter1
			// 
			this.bevelledGradientProgressPainter1.GlossPainter = null;
			this.bevelledGradientProgressPainter1.MaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.bevelledGradientProgressPainter1.MinColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.bevelledGradientProgressPainter1.ProgressBorderPainter = null;
			// 
			// candyCaneBackgroundPainter1
			// 
			this.candyCaneBackgroundPainter1.GlossPainter = null;
			// 
			// rarBackgroundPainter1
			// 
			this.rarBackgroundPainter1.GlossPainter = null;
			// 
			// rarProgressPainter1
			// 
			this.rarProgressPainter1.GlossPainter = null;
			this.rarProgressPainter1.ProgressBorderPainter = null;
			this.rarProgressPainter1.ProgressType = ProgressODoom.RarProgressPainter.RarProgressType.Silver;
			this.rarProgressPainter1.ShowEdge = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(12, 285);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(121, 22);
			this.button5.TabIndex = 16;
			this.button5.Text = "Glosses";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Location = new System.Drawing.Point(12, 104);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(201, 143);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 313);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(121, 22);
			this.button3.TabIndex = 18;
			this.button3.Text = "Duals";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(12, 341);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(121, 22);
			this.button6.TabIndex = 19;
			this.button6.Text = "Marquee";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 370);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.comboBox4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.progressBarEx1);
			this.Controls.Add(this.trackBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Progress-O-Doom";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ProgressODoom.ProgressBarEx progressBarEx1;
		private System.Windows.Forms.Button button1;
		private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
		private ProgressODoom.PlainBorderPainter plainBorderPainter1;
		private ProgressODoom.PlainProgressPainter plainProgressPainter1;
		private ProgressODoom.BarberPoleProgressPainter barberPoleProgressPainter1;
		private ProgressODoom.JavaProgressPainter javaProgressPainter1;
		private ProgressODoom.GradientBackgroundPainter gradientBackgroundPainter1;
		private ProgressODoom.FruityLoopsProgressPainter fruityLoopsProgressPainter1;
		private ProgressODoom.FruityLoopsBackgroundPainter fruityLoopsBackgroundPainter1;
		private ProgressODoom.MetalProgressPainter metalProgressPainter1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
		private ProgressODoom.StyledBorderPainter styledBorderPainter1;
		private System.Windows.Forms.ComboBox comboBox4;
		private ProgressODoom.BevelledProgressPainter bevelledProgressPainter1;
		private ProgressODoom.BevelledGradientProgressPainter bevelledGradientProgressPainter1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private ProgressODoom.CandyCaneBackgroundPainter candyCaneBackgroundPainter1;
		private ProgressODoom.CandyCaneProgressPainter candyCaneProgressPainter1;
		private ProgressODoom.RoundGlossPainter roundGlossPainter1;
		private ProgressODoom.RoundGlossPainter roundGlossPainter2;
		private ProgressODoom.MiddleGlossPainter middleGlossPainter1;
		private ProgressODoom.FlatGlossPainter flatGlossPainter1;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter1;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter2;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter3;
		private ProgressODoom.GradientGlossPainter gradientGlossPainter4;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button button4;
		private ProgressODoom.RarBackgroundPainter rarBackgroundPainter1;
		private ProgressODoom.RarBorderPainter rarBorderPainter1;
		private ProgressODoom.RarProgressPainter rarProgressPainter1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button6;
	}
}

