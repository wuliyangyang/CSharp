namespace NetTool.UserControls
{
    partial class SerialPanel
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.comboBoxRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxTimeStamp = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sendMsgPanel1 = new NetTool.UserControls.SendMsgPanel();
            this.logPanel1 = new NetTool.UserControls.LogPanel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(388, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 37);
            this.label2.TabIndex = 17;
            this.label2.Text = "COM:";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(189, 28);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(170, 41);
            this.btnDisConnect.TabIndex = 13;
            this.btnDisConnect.Text = "Close";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(31, 28);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(135, 41);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Open";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(487, 31);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(121, 32);
            this.comboBoxCOM.TabIndex = 18;
            // 
            // comboBoxRate
            // 
            this.comboBoxRate.FormattingEnabled = true;
            this.comboBoxRate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400"});
            this.comboBoxRate.Location = new System.Drawing.Point(756, 31);
            this.comboBoxRate.Name = "comboBoxRate";
            this.comboBoxRate.Size = new System.Drawing.Size(145, 32);
            this.comboBoxRate.TabIndex = 20;
            this.comboBoxRate.Text = "115200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(638, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Rate:";
            // 
            // checkBoxTimeStamp
            // 
            this.checkBoxTimeStamp.AutoSize = true;
            this.checkBoxTimeStamp.Location = new System.Drawing.Point(975, 34);
            this.checkBoxTimeStamp.Name = "checkBoxTimeStamp";
            this.checkBoxTimeStamp.Size = new System.Drawing.Size(150, 28);
            this.checkBoxTimeStamp.TabIndex = 23;
            this.checkBoxTimeStamp.Text = "TimeStamp";
            this.checkBoxTimeStamp.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear.Location = new System.Drawing.Point(1163, 31);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(161, 45);
            this.buttonClear.TabIndex = 24;
            this.buttonClear.Text = "ClearLog";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sendMsgPanel1
            // 
            this.sendMsgPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sendMsgPanel1.Location = new System.Drawing.Point(731, 82);
            this.sendMsgPanel1.Name = "sendMsgPanel1";
            this.sendMsgPanel1.Size = new System.Drawing.Size(602, 644);
            this.sendMsgPanel1.TabIndex = 22;
            // 
            // logPanel1
            // 
            this.logPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logPanel1.Location = new System.Drawing.Point(26, 82);
            this.logPanel1.Name = "logPanel1";
            this.logPanel1.RecvLog = "\r\n";
            this.logPanel1.SendLog = "\r\n";
            this.logPanel1.Size = new System.Drawing.Size(669, 644);
            this.logPanel1.TabIndex = 21;
            // 
            // SerialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.checkBoxTimeStamp);
            this.Controls.Add(this.sendMsgPanel1);
            this.Controls.Add(this.logPanel1);
            this.Controls.Add(this.comboBoxRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "SerialPanel";
            this.Size = new System.Drawing.Size(1595, 1049);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.ComboBox comboBoxRate;
        private System.Windows.Forms.Label label1;
        private LogPanel logPanel1;
        private SendMsgPanel sendMsgPanel1;
        private System.Windows.Forms.CheckBox checkBoxTimeStamp;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer1;
    }
}
