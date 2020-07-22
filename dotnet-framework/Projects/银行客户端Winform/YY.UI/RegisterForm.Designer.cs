namespace YY.UI
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.textEditAccount = new DevExpress.XtraEditors.TextEdit();
            this.textEditPwd = new DevExpress.XtraEditors.TextEdit();
            this.textEditMoney = new DevExpress.XtraEditors.TextEdit();
            this.OkBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoney.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "姓名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(38, 160);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 29);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "账号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(38, 338);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 29);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "金额：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 249);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 29);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "密码：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(356, 329);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(159, 29);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "（最低100元）";
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(140, 64);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(200, 44);
            this.textEditName.TabIndex = 5;
            // 
            // textEditAccount
            // 
            this.textEditAccount.Location = new System.Drawing.Point(140, 154);
            this.textEditAccount.Name = "textEditAccount";
            this.textEditAccount.Size = new System.Drawing.Size(200, 44);
            this.textEditAccount.TabIndex = 6;
            // 
            // textEditPwd
            // 
            this.textEditPwd.Location = new System.Drawing.Point(140, 234);
            this.textEditPwd.Name = "textEditPwd";
            this.textEditPwd.Properties.PasswordChar = '*';
            this.textEditPwd.Size = new System.Drawing.Size(200, 44);
            this.textEditPwd.TabIndex = 7;
            // 
            // textEditMoney
            // 
            this.textEditMoney.Location = new System.Drawing.Point(140, 323);
            this.textEditMoney.Name = "textEditMoney";
            this.textEditMoney.Size = new System.Drawing.Size(200, 44);
            this.textEditMoney.TabIndex = 8;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(140, 407);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(200, 46);
            this.OkBtn.TabIndex = 9;
            this.OkBtn.Text = "确认";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 465);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.textEditMoney);
            this.Controls.Add(this.textEditPwd);
            this.Controls.Add(this.textEditAccount);
            this.Controls.Add(this.textEditName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoney.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.TextEdit textEditAccount;
        private DevExpress.XtraEditors.TextEdit textEditPwd;
        private DevExpress.XtraEditors.TextEdit textEditMoney;
        private DevExpress.XtraEditors.SimpleButton OkBtn;
    }
}