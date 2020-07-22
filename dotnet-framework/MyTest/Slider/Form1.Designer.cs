namespace Slider
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Board = new System.Windows.Forms.Panel();
            this.panel_Slider = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_Board.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Board
            // 
            this.panel_Board.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Board.Controls.Add(this.panel_Slider);
            this.panel_Board.Location = new System.Drawing.Point(136, 126);
            this.panel_Board.Name = "panel_Board";
            this.panel_Board.Size = new System.Drawing.Size(540, 85);
            this.panel_Board.TabIndex = 0;
            // 
            // panel_Slider
            // 
            this.panel_Slider.BackColor = System.Drawing.Color.Lime;
            this.panel_Slider.Location = new System.Drawing.Point(3, 12);
            this.panel_Slider.Name = "panel_Slider";
            this.panel_Slider.Size = new System.Drawing.Size(90, 62);
            this.panel_Slider.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(136, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "演示";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 667);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_Board);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_Board.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Board;
        private System.Windows.Forms.Panel panel_Slider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

