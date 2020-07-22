using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace OxyPlotWinform
{
    public partial class FrmTwoColorLineSeries : Form
    {
        public FrmTwoColorLineSeries()
        {
            InitializeComponent();
        }

        private void FrmTwoColorLineSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel { Title = "TwoColorLineSeries" };
            var twoColorLineSeries = new TwoColorLineSeries
            {
                Color = OxyColors.Red,
                Color2 = OxyColors.Green,
                LineStyle = LineStyle.Solid,
                LineStyle2 = LineStyle.Dot
            };
            twoColorLineSeries.Points.Add(new DataPoint(0, -6));
            twoColorLineSeries.Points.Add(new DataPoint(10, 4));
            twoColorLineSeries.Points.Add(new DataPoint(30, -2));
            twoColorLineSeries.Points.Add(new DataPoint(40, 8));
            model.Series.Add(twoColorLineSeries);

            plotView1.Model = model;
        }
    }
}
