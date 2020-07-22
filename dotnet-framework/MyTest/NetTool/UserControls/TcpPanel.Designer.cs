namespace NetTool.UserControls
{
    partial class TcpPanel
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxTimestamp = new System.Windows.Forms.CheckBox();
            this.sendMsgPanel1 = new NetTool.UserControls.SendMsgPanel();
            this.logPanel1 = new NetTool.UserControls.LogPanel();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear.Location = new System.Drawing.Point(1188, 33);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(161, 45);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "ClearLog";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBoxTimestamp
            // 
            this.checkBoxTimestamp.AutoSize = true;
            this.checkBoxTimestamp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxTimestamp.Location = new System.Drawing.Point(963, 32);
            this.checkBoxTimestamp.Name = "checkBoxTimestamp";
            this.checkBoxTimestamp.Size = new System.Drawing.Size(220, 45);
            this.checkBoxTimestamp.TabIndex = 4;
            this.checkBoxTimestamp.Text = "Timestamp";
            this.checkBoxTimestamp.UseVisualStyleBackColor = true;
            // 
            // sendMsgPanel1
            // 
            this.sendMsgPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sendMsgPanel1.Location = new System.Drawing.Point(754, 84);
            this.sendMsgPanel1.Name = "sendMsgPanel1";
            this.sendMsgPanel1.Size = new System.Drawing.Size(605, 653);
            this.sendMsgPanel1.TabIndex = 2;
            // 
            // logPanel1
            // 
            this.logPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logPanel1.Location = new System.Drawing.Point(38, 84);
            this.logPanel1.Name = "logPanel1";
            this.logPanel1.RecvLog = "\r\n\r\n\r\n\r\n\r\n";
            this.logPanel1.SendLog = "\r\n\r\n\r\n\r\n\r\n";
            this.logPanel1.Size = new System.Drawing.Size(672, 653);
            this.logPanel1.TabIndex = 1;
            // 
            // TcpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxTimestamp);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.sendMsgPanel1);
            this.Controls.Add(this.logPanel1);
            this.Name = "TcpPanel";
            this.Size = new System.Drawing.Size(1718, 1019);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LogPanel logPanel1;
        private SendMsgPanel sendMsgPanel1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxTimestamp;
    }
}
