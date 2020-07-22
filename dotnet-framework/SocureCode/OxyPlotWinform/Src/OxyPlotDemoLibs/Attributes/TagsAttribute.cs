/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs.Attributes
 *文件名:TabsAttribute
 *版本号:V1.0.0.0
 *唯一标识:fca079e0-7bba-4e1d-99ca-f9299410dd2d
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:21:05

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:21:05
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

namespace OxyPlotDemoLibs.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TagsAttribute:Attribute
    {
        public TagsAttribute(params string[] tags)
        {
            Tags = tags;
        }
        public string[] Tags { get; private set; }
    }
}
