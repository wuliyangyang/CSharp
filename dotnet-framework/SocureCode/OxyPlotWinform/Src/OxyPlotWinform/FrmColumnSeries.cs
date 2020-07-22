using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace OxyPlotWinform
{
    public partial class FrmColumnSeries : Form
    {
        public FrmColumnSeries()
        {
            InitializeComponent();
        }

        private void FrmColumnSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel()
            {
                Title = "中文"
            };

            var Items = new List<ColumnItem>();

            Items.Add(new ColumnItem(34.45, 1));
            Items.Add(new ColumnItem(33.45, 2));
            Items.Add(new ColumnItem(32.45, 3));
            Items.Add(new ColumnItem(44.45, 4));
            Items.Add(new ColumnItem(43.45, 5));
            Items.Add(new ColumnItem(42.45, 6));

            ColumnSeries series = new ColumnSeries();
            series.Items.AddRange(Items);

            model.Series.Add(series);

            plotView1.Model = model;
        }
    }
}
