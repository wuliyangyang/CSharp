namespace YY.UI
{
    partial class LoginForm
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
            this.textEditPwd = new DevExpress.XtraEditors.TextEdit();
            this.LoginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.RegistBtn = new DevExpress.XtraEditors.SimpleButton();
            this.lable = new DevExpress.XtraEditors.LabelControl();
            this.comboEditAccount = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 128);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "账号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(93, 205);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 29);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密码：";
            // 
            // textEditPwd
            // 
            this.textEditPwd.EditValue = "888888";
            this.textEditPwd.Location = new System.Drawing.Point(171, 199);
            this.textEditPwd.Name = "textEditPwd";
            this.textEditPwd.Properties.PasswordChar = '*';
            this.textEditPwd.Size = new System.Drawing.Size(200, 44);
            this.textEditPwd.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(89, 328);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(150, 46);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "登录";
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // RegistBtn
            // 
            this.RegistBtn.Location = new System.Drawing.Point(295, 328);
            this.RegistBtn.Name = "RegistBtn";
            this.RegistBtn.Size = new System.Drawing.Size(150, 46);
            this.RegistBtn.TabIndex = 5;
            this.RegistBtn.Text = "注册";
            this.RegistBtn.Click += new System.EventHandler(this.RegistBtn_Click);
            // 
            // lable
            // 
            this.lable.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Appearance.Options.UseFont = true;
            this.lable.Location = new System.Drawing.Point(171, 42);
            this.lable.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(192, 39);
            this.lable.TabIndex = 6;
            this.lable.Text = "银行登录首页";
            // 
            // comboEditAccount
            // 
            this.comboEditAccount.FormattingEnabled = true;
            this.comboEditAccount.Location = new System.Drawing.Point(171, 120);
            this.comboEditAccount.Name = "comboEditAccount";
            this.comboEditAccount.Size = new System.Drawing.Size(200, 37);
            this.comboEditAccount.TabIndex = 8;
            this.comboEditAccount.Text = "zhangsan";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 443);
            this.Controls.Add(this.comboEditAccount);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.RegistBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.textEditPwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditPwd;
        private DevExpress.XtraEditors.SimpleButton LoginBtn;
        private DevExpress.XtraEditors.SimpleButton RegistBtn;
        private DevExpress.XtraEditors.LabelControl lable;
        private System.Windows.Forms.ComboBox comboEditAccount;
    }
}

