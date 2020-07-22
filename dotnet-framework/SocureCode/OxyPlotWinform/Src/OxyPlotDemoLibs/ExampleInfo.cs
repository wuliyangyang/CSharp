/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs
 *文件名:ExampleInfo
 *版本号:V1.0.0.0
 *唯一标识:0e79cedd-46f5-4692-a69b-5756a78f7f8d
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:23:56

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:23:56
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace OxyPlotDemoLibs
{
    public class ExampleInfo
    {
        
        private readonly MethodInfo method;

        private object result;

        public ExampleInfo(string category,string title,string[] tags,MethodInfo method)
        {
            Category = category;
            Title = title;
            Tags = tags;
            this.method = method;
        }

        public string Category { get; private set; }
        public string Title { get; private set; }
        public string[] Tags { get; private set; }

        public PlotModel PlotModel
        {
            get
            {
                var plotModel = this.result as PlotModel;
                if (null != plotModel)
                {
                    return plotModel;
                }

                var example = Result as Example;
                return example != null ? example.Model : null;
            }
        }

        public IPlotController PlotController
        {
            get
            {
                var example = Result as Example;
                return example != null ? example.Controller : null;
            }
        }
        public string Code
        {
            get { return PlotModel != null ? this.PlotModel.ToCode() : null; }
        }

        private object Result
        {
            get { return this.result ?? (result = this.method.Invoke(null, null)); }
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
