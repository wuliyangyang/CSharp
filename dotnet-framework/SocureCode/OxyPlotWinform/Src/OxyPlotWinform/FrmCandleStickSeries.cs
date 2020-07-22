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
    public partial class FrmCandleStickSeries : Form
    {
        public FrmCandleStickSeries()
        {
            InitializeComponent();
        }

        private void FrmCandleStickSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel()
            {
                Title = "CandleStickSeries"
            };

            List<MinuteRec> lst = new List<MinuteRec>
            {
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:31:00"), O = 1672.5000, H = 1673.5000, L = 1671.7500, C = 1672.7500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:32:00"), O = 1672.5000, H = 1673.5000, L = 1672.5000, C = 1672.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:33:00"), O = 1672.5000, H = 1672.7500, L = 1670.7500, C = 1671.2500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:34:00"), O = 1671.2500, H = 1671.2500, L = 1670.2500, C = 1670.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:35:00"), O = 1670.7500, H = 1671.7500, L = 1670.5000, C = 1671.2500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:36:00"), O = 1671.0000, H = 1672.5000, L = 1671.0000, C = 1672.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:37:00"), O = 1672.5000, H = 1673.0000, L = 1672.0000, C = 1673.0000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:38:00"), O = 1672.7500, H = 1673.2500, L = 1672.5000, C = 1672.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:39:00"), O = 1672.5000, H = 1672.7500, L = 1671.2500, C = 1671.2500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:40:00"), O = 1671.2500, H = 1672.5000, L = 1671.0000, C = 1672.0000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:41:00"), O = 1672.2500, H = 1672.5000, L = 1671.2500, C = 1672.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:42:00"), O = 1672.2500, H = 1672.5000, L = 1671.5000, C = 1671.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:43:00"), O = 1671.5000, H = 1671.7500, L = 1670.5000, C = 1671.0000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:44:00"), O = 1670.7500, H = 1671.7500, L = 1670.7500, C = 1671.7500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:45:00"), O = 1672.0000, H = 1672.2500, L = 1671.5000, C = 1671.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:46:00"), O = 1671.7500, H = 1671.7500, L = 1671.0000, C = 1671.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:47:00"), O = 1671.7500, H = 1672.2500, L = 1671.5000, C = 1671.7500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:48:00"), O = 1671.7500, H = 1672.7500, L = 1671.7500, C = 1672.5000},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:49:00"), O = 1672.2500, H = 1673.7500, L = 1672.2500, C = 1673.7500},
                new MinuteRec
                    {QTime = TimeSpan.Parse("06:50:00"), O = 1673.7500, H = 1675.0000, L = 1673.5000, C = 1675.0000}
            };

            var timeSpanAxis1 = new TimeSpanAxis {Position = AxisPosition.Bottom, StringFormat = "hh:mm"};
            model.Axes.Add(timeSpanAxis1);

            CandleStickSeries series= new CandleStickSeries()
            {
                CandleWidth = 1,
                IncreasingColor = OxyColors.DarkGreen,
                DecreasingColor = OxyColors.Red,
                DataFieldX = "QTime",
                DataFieldHigh = "H",
                DataFieldLow = "L",
                DataFieldOpen = "O",
                DataFieldClose = "C",
                //TrackerFormatString = "High: {2:0.00}\nLow: {3:0.00}\nOpen: {4:0.00}\nClose: {5:0.00}",
                ItemsSource = lst
            };
            
            //series.LineStyle = LineStyle.DashDashDot;

            
            // var x    = new List<HighLowItem>()
            //{
            //    new HighLowItem(d.ToOADate(),40,20),
            //    new HighLowItem(d.AddMinutes(1).ToOADate(),40,20),
            //    new HighLowItem(d.AddMinutes(2).ToOADate(),40,20),
            //};
            //series.Items.AddRange(x);
            model.Series.Add(series);
            plotView1.Model = model;
        }
    }

    public class MinuteRec
    {
        public TimeSpan QTime { get; set; }
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
    }
}
