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
    public partial class FrmPieSeries : Form
    {
        public FrmPieSeries()
        {
            InitializeComponent();
        }

        private void FrmPieSeries_Load(object sender, EventArgs e)
        {
            var model = new PlotModel()
            {
                Title = "World population by contnent",
            };

            
            var pie = new PieSeries()
            {
                StrokeThickness = 0.25,
                InsideLabelPosition = 0.5,
                AngleSpan = 360,
                StartAngle = 0
            };

            pie.Slices.Add(new PieSlice("Africa",1030) {IsExploded = false});
            pie.Slices.Add(new PieSlice("Americas", 929) { IsExploded = false });
            pie.Slices.Add(new PieSlice("Asia", 4157) );
            pie.Slices.Add(new PieSlice("Europe", 739) { IsExploded = false });
            pie.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = false });

            model.Series.Add(pie);
            plotView1.Model = model;
        }
    }
}
