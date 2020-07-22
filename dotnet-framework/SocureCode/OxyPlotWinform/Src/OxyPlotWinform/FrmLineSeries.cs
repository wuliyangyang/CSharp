using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using Image = OxyPlot.Reporting.Image;
using SvgExporter = OxyPlot.WindowsForms.SvgExporter;

namespace OxyPlotWinform
{
    public partial class FrmLineSeries : Form
    {
        private DateTimeAxis _dateAxis;//X轴
        private LinearAxis _valueAxis;//Y轴
        
        private PlotModel _myPlotModel;
        private Random rand = new Random();//用来生成随机数
        public FrmLineSeries()
        {
            InitializeComponent();
            System.Drawing.StringFormat.GenericTypographic.FormatFlags &= ~StringFormatFlags.LineLimit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //定义model
            _myPlotModel = new PlotModel()
            {
                Title = "Temp & Humi 温度",
                LegendTitle =  "Legend",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement =  LegendPlacement.Inside,
                LegendPosition =  LegendPosition.TopRight,
                LegendBackground = OxyColor.FromAColor(200,OxyColors.Beige),
                LegendBorder = OxyColors.Black,
                DefaultFont = "微软雅黑",
            };
            //X轴
            _dateAxis = new DateTimeAxis()
            {
                MajorGridlineStyle =  LineStyle.Solid,
                MinorGridlineStyle =  LineStyle.Dot,
                IntervalLength =  80,
                IsZoomEnabled = false,
                IsPanEnabled =  false,
                StringFormat = "hh:mm:ss",
                Title = "时间"
            };
            _myPlotModel.Axes.Add(_dateAxis);

            //Y轴
            _valueAxis = new LinearAxis()
            {
                MajorGridlineStyle =  LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                IntervalLength = 80,
                Angle = 60,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Maximum = 100,
                Minimum = -1,
                Title = "数值"
            };
            _myPlotModel.Axes.Add(_valueAxis);

            //添加标注线，温度上下限和湿度上下限
            var lineTempMaxAnnotation = new OxyPlot.Annotations.LineAnnotation()
            {
                Type = LineAnnotationType.Horizontal,
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid,
                Y = 10,
                Text = "Temp MAX:10"
            };
            _myPlotModel.Annotations.Add(lineTempMaxAnnotation);

            var lineTempMinAnnotation = new LineAnnotation()
            {
                Type = LineAnnotationType.Horizontal,
                Y = 30,
                Text = "Temp Min:30",
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid
            };
            _myPlotModel.Annotations.Add(lineTempMinAnnotation);

            var lineHumiMaxAnnotation = new OxyPlot.Annotations.LineAnnotation()
            {
                Type = LineAnnotationType.Horizontal,
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid,
                //lineMaxAnnotation.MaximumX = 0.8;
                Y = 75,
                Text = "Humi MAX:75"
            };
            _myPlotModel.Annotations.Add(lineHumiMaxAnnotation);

            var lineHumiMinAnnotation = new LineAnnotation()
            {
                Type = LineAnnotationType.Horizontal,
                Y = 35,
                Text = "Humi Min:35",
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid
            };
            _myPlotModel.Annotations.Add(lineHumiMinAnnotation);

            //添加两条曲线
            var series = new LineSeries()
            {
                Color = OxyColors.Green,
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerType = MarkerType.Diamond,
                Title = "Temp",
                Smooth = true
            };
            _myPlotModel.Series.Add(series);
            series = new LineSeries()
            {
                Color = OxyColors.Blue,
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.BlueViolet,
                MarkerType = MarkerType.Star,
                Title = "Humi",
                Smooth = true
            };
            _myPlotModel.Series.Add(series);

            //plotView1.Font = Font;
            plotView1.Model = _myPlotModel;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    var date = DateTime.Now;
                    _myPlotModel.Axes[0].Maximum = DateTimeAxis.ToDouble(date.AddSeconds(1));

                    var lineSer = plotView1.Model.Series[0] as LineSeries;
                    lineSer.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), rand.Next(100, 300)/10.0));
                    if (lineSer.Points.Count > 100)
                    {
                        lineSer.Points.RemoveAt(0);
                    }

                    lineSer = plotView1.Model.Series[1] as LineSeries;
                    lineSer.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), rand.Next(350, 750)/10.0));
                    if (lineSer.Points.Count > 100)
                    {
                        lineSer.Points.RemoveAt(0);
                    }

                    _myPlotModel.InvalidatePlot(true);

                    Thread.Sleep(1000);
                }
            });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "aa.pdf");
            using (var s = File.Create(path))
            {
                PdfExporter.Export(plotView1.Model, s, 800, 500);

            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "aa.png");
            using (var s = File.Create(path))
            
            {
                PngExporter png = new PngExporter();
                png.Background = OxyColors.White;
                png.Export(plotView1.Model, s);
                //PngExporter.Export(plotView1.Model, "a.png", 800, 500);
                //PdfExporter.Export(plotView1.Model, s, 800, 500);

            }
        }
    }
}
