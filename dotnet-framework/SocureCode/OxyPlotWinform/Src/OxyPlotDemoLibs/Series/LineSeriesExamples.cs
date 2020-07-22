/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs.Series
 *文件名:LineSeriesExamples
 *版本号:V1.0.0.0
 *唯一标识:24f5c4ab-d53d-43dd-b60b-810a592e4659
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:50:04

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:50:04
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlotDemoLibs.Attributes;

namespace OxyPlotDemoLibs.Series
{
    [Examples("LineSeries"),Tags("Series")]
    public class LineSeriesExamples
    {
        [Example("Default Style")]
        public static PlotModel DefaultStyle()
        {
            var model = new PlotModel {Title = "LineSeries with Defualt Style"};
            model.Axes.Add(new LinearAxis {Position =  AxisPosition.Bottom});
            model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
            var lineSeries1 = CreateExampleLineSeries();
            lineSeries1.Title = "LineSeries 1";
            model.Series.Add(lineSeries1);
            return model;
        }

        private static OxyPlot.Series.Series CreateExampleLineSeries(int seed = 13)
        {
            var lineSeries1 = new LineSeries();
            var r = new Random(seed);
            var y = r.Next(10, 30);
            for (int x = 0; x <= 100; x+=10)
            {
                lineSeries1.Points.Add(new DataPoint(x,y));
                y += r.Next(-5, 5);
            }

            return lineSeries1;
        }
    }
}
