namespace NetTool.UserControls
{
    partial class SendMsgPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.textBoxLoop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEnding = new System.Windows.Forms.TextBox();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBoxCommand = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(30, 29);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(90, 28);
            this.loopCheckBox.TabIndex = 0;
            this.loopCheckBox.Text = "Loop";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBoxLoop
            // 
            this.textBoxLoop.Location = new System.Drawing.Point(187, 29);
            this.textBoxLoop.Name = "textBoxLoop";
            this.textBoxLoop.Size = new System.Drawing.Size(402, 35);
            this.textBoxLoop.TabIndex = 1;
            this.textBoxLoop.Text = "hello!!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interval(ms)";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(187, 84);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(402, 35);
            this.textBoxInterval.TabIndex = 3;
            this.textBoxInterval.Text = "500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Endings";
            // 
            // textBoxEnding
            // 
            this.textBoxEnding.Enabled = false;
            this.textBoxEnding.Location = new System.Drawing.Point(187, 146);
            this.textBoxEnding.Name = "textBoxEnding";
            this.textBoxEnding.Size = new System.Drawing.Size(402, 35);
            this.textBoxEnding.TabIndex = 5;
            this.textBoxEnding.Text = "\\r\\n";
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(30, 304);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(559, 281);
            this.textBoxSend.TabIndex = 6;
            this.textBoxSend.Text = "hello!!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Commands";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(435, 247);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(154, 51);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBoxCommand
            // 
            this.comboBoxCommand.FormattingEnabled = true;
            this.comboBoxCommand.Location = new System.Drawing.Point(30, 591);
            this.comboBoxCommand.Name = "comboBoxCommand";
            this.comboBoxCommand.Size = new System.Drawing.Size(559, 32);
            this.comboBoxCommand.TabIndex = 10;
            // 
            // SendMsgPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxCommand);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.textBoxEnding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLoop);
            this.Controls.Add(this.loopCheckBox);
            this.Name = "SendMsgPanel";
            this.Size = new System.Drawing.Size(623, 651);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox loopCheckBox;
        private System.Windows.Forms.TextBox textBoxLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEnding;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBoxCommand;
    }
}
