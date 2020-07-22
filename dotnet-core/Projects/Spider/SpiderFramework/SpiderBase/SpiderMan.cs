using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace SpiderBase
{
    public class SpiderMan
    {

        static string serviceAssembly = ConfigurationManager.AppSettings["SpiderPlugin"];
        static string pipelineAssembly = ConfigurationManager.AppSettings["Pipeline"];
        
        public static void Start()
        {
            BaseSpiderUtility spider = GetInstance<BaseSpiderUtility>(serviceAssembly);
            IPipelines pipelines = GetInstance<IPipelines>(pipelineAssembly);
            spider.GetImgSrc = pipelines.ProcessItem;
            spider.Parse();
        }

        private static T GetInstance<T>(string  name)
        {
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "/Plugins/netcoreapp3.1/";
            string className = name.Split(',')[0];
            string dllName = name.Split(',')[1];
            Assembly assembly = Assembly.LoadFrom (dllPath+dllName);
            Type type = assembly.GetType(className);
            T t = (T)Activator.CreateInstance(type);
            return t;
        }
    }
}
