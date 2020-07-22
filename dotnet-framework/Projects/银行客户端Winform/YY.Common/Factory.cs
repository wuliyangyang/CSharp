using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YY.IBLL;
namespace CommonLibs
{
    public class Factory
    {
        static string serviceAssembly = ConfigurationManager.AppSettings["Service"];
        public static IUserServiceBLL GetServiceInstance()
        {
            IUserServiceBLL service = GetInstance<IUserServiceBLL>(serviceAssembly);
            return service;
        }
        private static T GetInstance<T>(string name)
        {
            string dllName = name.Split(',')[1];
            string className = name.Split(',')[0];
            Assembly assembly = Assembly.Load(dllName);
            Type type = assembly.GetType(className);
            T t = (T)Activator.CreateInstance(type);
            return t;
        }
    }
}
