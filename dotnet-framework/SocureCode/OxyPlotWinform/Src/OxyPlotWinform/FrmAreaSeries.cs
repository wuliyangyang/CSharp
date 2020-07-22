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
    public partial class FrmAreaSeries : Form
    {
        public FrmAreaSeries()
        {
            InitializeComponent();
        }

        private void FrmAreaSeries_Load(object sender, EventArgs e)
        {
            var plotModel = new PlotModel() {Title = "AreaSeries with crossing lines"};
            var areaSeries = new AreaSeries();
            areaSeries.Points.Add(new DataPoint(0, 50));
            areaSeries.Points.Add(new DataPoint(10, 140));
            areaSeries.Points.Add(new DataPoint(20, 60));
            areaSeries.Points2.Add(new DataPoint(0, 60));
            areaSeries.Points2.Add(new DataPoint(5, 80));
            areaSeries.Points2.Add(new DataPoint(20, 70));
            plotModel.Series.Add(areaSeries);

            plotView1.Model = plotModel;
        }
    }
}
