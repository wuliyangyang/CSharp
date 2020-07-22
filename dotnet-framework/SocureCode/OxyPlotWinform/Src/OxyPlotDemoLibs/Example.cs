/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs
 *文件名:Example
 *版本号:V1.0.0.0
 *唯一标识:a54f4495-4175-4934-80d9-2b5999d278d4
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:32:05

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:32:05
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

namespace OxyPlotDemoLibs
{
    public class Example
    {
        public PlotModel Model { get; private set; }
        public IPlotController Controller { get; private set; }

        public Example(PlotModel model,IPlotController controller = null)
        {
            Model = model;
            Controller = controller;
        }
    }
}
