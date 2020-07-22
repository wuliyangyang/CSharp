using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using LogTool;

namespace DockPanelControlTest
{
    public partial class Form1 : Form
    {
        FormDock form;
        public Form1()
        {
            InitializeComponent();
            IintCForm();
            var logPattern = "%d{yyyy-MM-dd HH:mm:ss} --%-5p-- %m%n";
            var textBox_logAppender = new TextBoxBaseAppender()
            {
                TextBox = form.TextBox,//注释后 就只有文件log
                Layout = new PatternLayout(logPattern)
            };
            log4net.Config.BasicConfigurator.Configure(textBox_logAppender);
        }
        private void IintCForm()
        {
            form = new FormDock();
            form.Text = "左边停靠";
            form.AutoHidePortion = 0.3;
            //form.CloseButtonVisible = false;
            form.Show(this.dockPanel1,DockState.DockLeftAutoHide);
        }
        private void 左边ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (form==null||form.IsDisposed)
            {
                form = new FormDock();
            }
            form.Text = "左边停靠";    
            form.Show(this.dockPanel1,DockState.DockLeftAutoHide);
         
            
        }

        static int n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            n += 1;
            Log.LogInfo("test msg " + n.ToString());
            
        }
    }

    public class TextBoxBaseAppender : AppenderSkeleton
    {
        public TextBoxBase TextBox { get; set; }

        public TextBoxBaseAppender()
        {
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (this.TextBox == null)
            {
                return;
            }

            if (!this.TextBox.IsHandleCreated)
            {
                return;
            }

            if (this.TextBox.IsDisposed)
            {
                return;
            }

            var patternLayout = this.Layout as PatternLayout;

            var str = string.Empty;
            if (patternLayout != null)
            {
                str = patternLayout.Format(loggingEvent);

                if (loggingEvent.ExceptionObject != null)
                {
                    str += loggingEvent.ExceptionObject.ToString() + Environment.NewLine;
                }
            }
            else
            {
                str = loggingEvent.LoggerName + "-" + loggingEvent.RenderedMessage + Environment.NewLine;
            }

            if (!this.TextBox.InvokeRequired)
            {
                printf(str);
            }
            else
            {
                this.TextBox.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.TextBox.IsHandleCreated)
                    {
                        return;
                    }

                    if (this.TextBox.IsDisposed)
                    {
                        return;
                    }
                    printf(str);
                });
            }
        }

        private void printf(string str)
        {
            //若是超过10行 则清楚  
            if (TextBox.Lines.Length > 50)
            {
                TextBox.Clear();
            }
            this.TextBox.AppendText(str);
        }
    }

}
