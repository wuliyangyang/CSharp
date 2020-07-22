namespace DockPanelControlTest
{
    partial class FormDock
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
            this.logtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logtextBox
            // 
            this.logtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logtextBox.Location = new System.Drawing.Point(0, 0);
            this.logtextBox.Multiline = true;
            this.logtextBox.Name = "logtextBox";
            this.logtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logtextBox.Size = new System.Drawing.Size(442, 658);
            this.logtextBox.TabIndex = 0;
            // 
            // FormDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 658);
            this.Controls.Add(this.logtextBox);
            this.Name = "FormDock";
            this.TabText = "FormDock";
            this.Text = "FormDock";
            this.DockStateChanged += new System.EventHandler(this.FormDock_DockStateChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDock_FormClosing);
            this.Shown += new System.EventHandler(this.FormDock_Shown);
            this.MouseLeave += new System.EventHandler(this.FormDock_MouseLeave);
            this.MouseHover += new System.EventHandler(this.FormDock_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logtextBox;
    }
}