using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式2
{
    class SingleObj
    {
        private static SingleObj instance = null;
        private SingleObj()
        {

        }

        public static SingleObj GetInstance()
        {
            if (instance==null)
            {
                instance = new SingleObj();
            }

            return instance;
        }

       static string value = ConfigurationManager.AppSettings["reflection"];
       static string dllName = value.Split(',')[0];
       static string className = value.Split(',')[1];     //完整的类名，包含命名空间  MNetMQ.PubSocket6

        public object FactoryCreat()
        {
            Assembly ab = Assembly.Load(dllName);
            Type type = ab.GetType(className);
            Object obj = Activator.CreateInstance(type);
            return obj;
        }
    }
}
