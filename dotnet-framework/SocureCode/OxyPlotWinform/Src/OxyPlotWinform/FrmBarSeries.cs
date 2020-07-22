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
using OxyPlot.Axes;
using OxyPlot.Series;

namespace OxyPlotWinform
{
    public partial class FrmBarSeries : Form
    {
        private PlotModel _barModel;
        public FrmBarSeries()
        {
            InitializeComponent();
        }

        private void FrmBarSeries_Load(object sender, EventArgs e)
        {
            _barModel = new PlotModel()
            {
                Title = "BarSeries",
                LegendPlacement =  LegendPlacement.Inside,
                LegendPosition =  LegendPosition.BottomCenter,
                LegendOrientation =  LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            BarSeries bar = new BarSeries()
            {
                Title = "Series 1",
                IsStacked = true,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            bar.BarWidth = 4;
           // bar.Title = "Bar1";
            bar.Items.Add( new BarItem() {Value = 20});
            bar.Items.Add(new BarItem() {  Value = 200 });
            bar.Items.Add(new BarItem() {  Value = 220 });
            bar.Items.Add(new BarItem() { Value = 180 });
            _barModel.Series.Add(bar);

            BarSeries s2 = new BarSeries()
            {
                Title = "Series 2",
                IsStacked = true,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            s2.BarWidth = 4;
            //s2.Title = "Bar2";
            s2.Items.Add(new BarItem() { Value = 60 });
            s2.Items.Add(new BarItem() { Value = 160 });
            s2.Items.Add(new BarItem() { Value = 30 });
            s2.Items.Add(new BarItem() { Value = 250 });
            _barModel.Series.Add(s2);

            BarSeries s3 = new BarSeries()
            {
                Title = "Series 2",
                IsStacked = true,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            s3.BarWidth = 4;
            s3.Items.Add(new BarItem() { Value = 86 });
            s3.Items.Add(new BarItem() { Value = 130 });
            s3.Items.Add(new BarItem() { Value = 190 });
            s3.Items.Add(new BarItem() { Value = 320 });
            _barModel.Series.Add(s3);

            var categoryAxis = new CategoryAxis() { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("category A");
            categoryAxis.Labels.Add("category B");
            categoryAxis.Labels.Add("category C");
            categoryAxis.Labels.Add("category D");

            var valueAxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,MinimumPadding = 0,MaximumPadding = 0.06,AbsoluteMinimum = 0
            };
            _barModel.Axes.Add(categoryAxis);
            _barModel.Axes.Add(valueAxis);

            plotView1.Model = _barModel;
        }
    }
}
