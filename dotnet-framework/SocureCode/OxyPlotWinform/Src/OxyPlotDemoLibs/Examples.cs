/*******************************************************************************************
 *Copyright (c) 2019  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:OxyPlotDemoLibs
 *文件名:Examples
 *版本号:V1.0.0.0
 *唯一标识:488fe3de-cd35-4dc2-94af-6aed5ac1c0d3
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2019/1/9 16:22:39

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2019/1/9 16:22:39
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
using OxyPlotDemoLibs.Attributes;

namespace OxyPlotDemoLibs
{
    public static class Examples
    {
        public static List<ExampleInfo> GetList()
        {
            var list = new List<ExampleInfo>();
            var assemblyTypes = typeof(Examples).GetTypeInfo().Assembly.DefinedTypes;

            foreach (var type in assemblyTypes)
            {
                var examplesAttribute = type.GetCustomAttributes<ExamplesAttribute>().FirstOrDefault();
                if (null == examplesAttribute)
                {
                    continue;
                }

                var examplesTags = type.GetCustomAttributes<TagsAttribute>().FirstOrDefault() ?? new TagsAttribute();
                var types = new List<Type>();
                var baseType = type;
                while (baseType !=null)
                {
                    types.Add(baseType.AsType());
                    baseType = baseType.BaseType != null ? baseType.BaseType.GetTypeInfo() : null;
                }

                foreach (var t in types)
                {
                    var methods = t.GetRuntimeMethods();

                    foreach (var method in methods)
                    {
                        try
                        {
                            var exampleAttribute = method.GetCustomAttributes<ExampleAttribute>().FirstOrDefault();
                            if (null != exampleAttribute)
                            {
                                var exampleTags = method.GetCustomAttributes<TagsAttribute>().FirstOrDefault() ??
                                                  new TagsAttribute();
                                var tags = new List<string>(examplesTags.Tags);
                                tags.AddRange(exampleTags.Tags);
                                list.Add(new ExampleInfo(examplesAttribute.Category, exampleAttribute.Title,
                                    tags.ToArray(), method));
                            }
                        }
                        catch (Exception e)
                        {
                            
                        }
                    }
                }
            }

            return list;
        }
    }
}
