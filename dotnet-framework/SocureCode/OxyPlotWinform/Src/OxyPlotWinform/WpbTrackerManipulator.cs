/*******************************************************************************************
 *Copyright (c) 2018  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotWinform
 *文件名:WpbTrackerManipulator
 *版本号:V1.0.0.0
 *唯一标识:b5d44756-b908-4a18-8b30-0c380d47a310
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2018/8/23 16:08:46

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2018/8/23 16:08:46
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace OxyPlotWinform
{
    public class WpbTrackerManipulator:MouseManipulator
    {
        private DataPointSeries currentSeries;
        public WpbTrackerManipulator(IPlotView plotView) : base(plotView)
        {
        }

        public override void Completed(OxyMouseEventArgs e)
        {
            base.Completed(e);
            e.Handled = true;

            currentSeries = null;
            PlotView.HideTracker();

        }

        public override void Delta(OxyMouseEventArgs e)
        {
            base.Delta(e);
            e.Handled = true;
            if (null == currentSeries)
            {
                PlotView.HideTracker();
                return;
            }
            var actualModel = PlotView.ActualModel;
            if (null == actualModel)
            {
                return;
            }
            if (!actualModel.PlotArea.Contains(e.Position.X, e.Position.Y))
            {
                return;
            }

            var time = currentSeries.InverseTransform(e.Position).X;
            var points = currentSeries.ItemsSource as Collection<DataPoint>;
            DataPoint dp = points.FirstOrDefault(d => d.X >= time);

            if (dp.X != 0 || dp.Y != 0)
            {
                int index = points.IndexOf(dp);
                var ss = PlotView.ActualModel.Series.Cast<DataPointSeries>();
                double[] values = new double[6];
                int i = 0;
                foreach (var series in ss)
                {
                    values[i++] = (series.ItemsSource as Collection<DataPoint>)[index].Y;

                }
                var position = XAxis.Transform(dp.X, dp.Y, currentSeries.YAxis);
                position = new ScreenPoint(position.X, e.Position.Y);

                var result = new WpbTrackerHitResult(values)
                {
                    Series = currentSeries,
                    DataPoint = dp,
                    Index = index,
                    Item = dp,
                    Position = position,
                    PlotModel = PlotView.ActualModel
                };
                PlotView.ShowTracker(result);
            }
        }

        public override void Started(OxyMouseEventArgs e)
        {
            base.Started(e);
            currentSeries = PlotView?.ActualModel?.Series.FirstOrDefault(s=>s.IsVisible) as DataPointSeries;

            Delta(e);
        }
    }

    public class WpbTrackerHitResult : TrackerHitResult
    {
        public double[] Values { get; private set; }

        [System.Runtime.CompilerServices.IndexerName("ValueString")]
        public string this[int index]
        {
            get { return string.Format((index == 1 || index == 4) ? "{0,7:###0}" : "{0,7:###0.0#}", Values[index]); }

        }

        public WpbTrackerHitResult(double[] values)
        {
            Values = values;
        }
    }
}
