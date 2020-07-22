using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OxyPlotWinform
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLineSeries_Click(object sender, EventArgs e)
        {
            new FrmLineSeries().Show();
        }

        private void BtnBarSeries_Click(object sender, EventArgs e)
        {
            new FrmBarSeries().Show();
        }

        private void BtnPieSeries_Click(object sender, EventArgs e)
        {
            new FrmPieSeries().Show();
        }

        private void BtnAreaSeries_Click(object sender, EventArgs e)
        {
            new FrmAreaSeries().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmStairStepSeries().Show();
        }

        private void BtnBoxPlotSeries_Click(object sender, EventArgs e)
        {
            new FrmBoxPlotSeries().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmCandleStickSeries().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmColumnSeries().Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new FrmTwoColorLineSeries().Show();
        }
    }
}
