/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs.Attributes
 *文件名:ExampleAttribute
 *版本号:V1.0.0.0
 *唯一标识:19052b4f-0730-4f91-92ce-1c713d0351d9
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:19:42

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:19:42
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

namespace OxyPlotDemoLibs.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExampleAttribute:Attribute
    {
        public ExampleAttribute(string title = null)
        {
            Title = title;
        }
        public string Title { get; private set; }
    }
}
