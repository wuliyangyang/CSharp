namespace YY.UI
{
    partial class UserOPForm
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
            this.components = new System.ComponentModel.Container();
            this.DrawBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SaveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.QueryBtn = new DevExpress.XtraEditors.SimpleButton();
            this.ExitBtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.PrintBtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditDays = new DevExpress.XtraEditors.TextEdit();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.OKBtn = new DevExpress.XtraEditors.SimpleButton();
            this.textEditMoney = new DevExpress.XtraEditors.TextEdit();
            this.actionLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelTime = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelWelcome = new DevExpress.XtraEditors.LabelControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoney.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBtn
            // 
            this.DrawBtn.Location = new System.Drawing.Point(0, 67);
            this.DrawBtn.Name = "DrawBtn";
            this.DrawBtn.Size = new System.Drawing.Size(150, 46);
            this.DrawBtn.TabIndex = 0;
            this.DrawBtn.Text = "取款";
            this.DrawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(0, 156);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(150, 46);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "存款";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // QueryBtn
            // 
            this.QueryBtn.Location = new System.Drawing.Point(0, 245);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(150, 46);
            this.QueryBtn.TabIndex = 2;
            this.QueryBtn.Text = "查询";
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(0, 423);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(150, 46);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "退出";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.PrintBtn);
            this.groupControl1.Controls.Add(this.DrawBtn);
            this.groupControl1.Controls.Add(this.ExitBtn);
            this.groupControl1.Controls.Add(this.SaveBtn);
            this.groupControl1.Controls.Add(this.QueryBtn);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(158, 478);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "操作选择";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(0, 334);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(150, 46);
            this.PrintBtn.TabIndex = 4;
            this.PrintBtn.Text = "打印";
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Controls.Add(this.OKBtn);
            this.groupControl2.Controls.Add(this.textEditMoney);
            this.groupControl2.Controls.Add(this.actionLabel);
            this.groupControl2.Location = new System.Drawing.Point(192, 26);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(510, 478);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "业务";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.textEditDays);
            this.groupControl3.Controls.Add(this.radioButton1);
            this.groupControl3.Controls.Add(this.radioButton2);
            this.groupControl3.Controls.Add(this.radioButton3);
            this.groupControl3.Location = new System.Drawing.Point(137, 216);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(342, 185);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "存款方式";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(184, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 34);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "2years";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(269, 135);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 34);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "days";
            // 
            // textEditDays
            // 
            this.textEditDays.EditValue = "0";
            this.textEditDays.Location = new System.Drawing.Point(184, 132);
            this.textEditDays.Name = "textEditDays";
            this.textEditDays.Size = new System.Drawing.Size(79, 44);
            this.textEditDays.TabIndex = 7;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 33);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "活期";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 91);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 33);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "死期";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 137);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(140, 33);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "灵活理财";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(137, 407);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(213, 46);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "确认";
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // textEditMoney
            // 
            this.textEditMoney.EditValue = "0";
            this.textEditMoney.Location = new System.Drawing.Point(137, 149);
            this.textEditMoney.Name = "textEditMoney";
            this.textEditMoney.Size = new System.Drawing.Size(213, 44);
            this.textEditMoney.TabIndex = 5;
            // 
            // actionLabel
            // 
            this.actionLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.Appearance.Options.UseFont = true;
            this.actionLabel.Location = new System.Drawing.Point(184, 67);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(105, 48);
            this.actionLabel.TabIndex = 4;
            this.actionLabel.Text = "action";
            // 
            // labelTime
            // 
            this.labelTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Appearance.Options.UseFont = true;
            this.labelTime.Location = new System.Drawing.Point(12, 527);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 48);
            this.labelTime.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelWelcome
            // 
            this.labelWelcome.Appearance.Font = new System.Drawing.Font("Tahoma", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Appearance.Options.UseFont = true;
            this.labelWelcome.Location = new System.Drawing.Point(241, 176);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(394, 52);
            this.labelWelcome.TabIndex = 7;
            this.labelWelcome.Text = "欢迎使用YY国际银行";
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Caption = "请稍等";
            this.progressPanel1.Description = "正在打印。。。";
            this.progressPanel1.Location = new System.Drawing.Point(313, 271);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 90);
            this.progressPanel1.TabIndex = 8;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // labelName
            // 
            this.labelName.Appearance.Font = new System.Drawing.Font("Tahoma", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Appearance.Options.UseFont = true;
            this.labelName.Location = new System.Drawing.Point(353, 118);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(172, 52);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "张三先生";
            // 
            // UserOPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 574);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.labelName);
            this.Name = "UserOPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserOPForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserOPForm_FormClosing);
            this.Load += new System.EventHandler(this.UserOPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoney.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton DrawBtn;
        private DevExpress.XtraEditors.SimpleButton SaveBtn;
        private DevExpress.XtraEditors.SimpleButton QueryBtn;
        private DevExpress.XtraEditors.SimpleButton ExitBtn;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton OKBtn;
        private DevExpress.XtraEditors.TextEdit textEditMoney;
        private DevExpress.XtraEditors.LabelControl actionLabel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevExpress.XtraEditors.SimpleButton PrintBtn;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit textEditDays;
        private DevExpress.XtraEditors.LabelControl labelTime;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labelWelcome;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelName;
    }
}