using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;

namespace YY.SOA.WebApi
{
    public class ContainerFactory
    {
        private static IUnityContainer container = null;
        static ContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Unities\\CfgFiles\\Unity.Config");
            if (!File.Exists(fileMap.ExeConfigFilename)) throw new Exception("Config file do not exist");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            container = new UnityContainer();
            section.Configure(container, "WebApiContainer");
        }

        public static IUnityContainer GetContainer()
        {
            return container;
        }
    }
}
