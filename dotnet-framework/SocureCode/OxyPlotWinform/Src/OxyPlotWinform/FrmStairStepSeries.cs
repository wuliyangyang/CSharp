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
    public partial class FrmStairStepSeries : Form
    {
        public FrmStairStepSeries()
        {
            InitializeComponent();
        }

        private void FrmStairStepSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel()
            {
                Title = "StairStep"
            };

            for (int j = 0; j < 1; j++)
            {
                StairStepSeries sss = new StairStepSeries {Title = "Serie" + j};


                sss.Points.AddRange(new List<DataPoint>
                {
                    new DataPoint(0, 32),
                    new DataPoint(1, 23), new DataPoint(2, 54), new DataPoint(3, 32), new DataPoint(4, 65),
                    new DataPoint(5, 29), new DataPoint(6, 25), new DataPoint(7, 12), new DataPoint(8, 24),
                    new DataPoint(9, 32), new DataPoint(10, 25)
                });

                model.Series.Add(sss);
            }           

            plotView1.Model = model;
        }
    }
}
