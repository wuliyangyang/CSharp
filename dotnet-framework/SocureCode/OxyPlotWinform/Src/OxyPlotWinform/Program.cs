using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OxyPlotWinform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Drawing.StringFormat.GenericTypographic.FormatFlags &= ~System.Drawing.StringFormatFlags.LineLimit;

            

            Application.Run(new FrmMain());
        }
    }
}
