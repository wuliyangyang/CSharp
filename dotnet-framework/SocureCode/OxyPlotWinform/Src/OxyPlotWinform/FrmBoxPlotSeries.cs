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
    public partial class FrmBoxPlotSeries : Form
    {
        public FrmBoxPlotSeries()
        {
            InitializeComponent();
        }

        private void FrmBoxPlotSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel()
            {
                Title = "BoxPlot"
            };

            BoxPlotSeries boxPlotSeries = new BoxPlotSeries();

            boxPlotSeries.LineStyle = LineStyle.DashDashDot;

            //BoxPlotItem item = new BoxPlotItem();
            boxPlotSeries.Items = new List<BoxPlotItem>()
            {
                new BoxPlotItem(1, 10, 15, 20, 25, 30),
                new BoxPlotItem(2, 10, 15, 20, 25, 30),
                new BoxPlotItem(3, 10, 15, 20, 25, 30),
                new BoxPlotItem(4, 12, 18, 28, 35, 46)
            };

            
            model.Series.Add(boxPlotSeries);
            plotView1.Model = model;
        }
    }
}
