using DesignMode3.Configuration.Decorators;
using DesignMode3.Configuration.FileReaders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration.Builders
{
    /// <summary>
    /// 建造者类
    /// </summary>
    public class ConfigurationBuilder
    {
        private MConfiguration _configuration = new MConfiguration();

        public ConfigurationBuilder AddJsonFileData(string filePath)
        {
            //read json file
            //扩展（装饰器模式）：
            //1.排序
            //2.去重
            //3.安全获取

            Console.WriteLine($"filePath:{filePath}");
            JsonFileReader jsonFileReader = new JsonFileReader();
            SortJsonFileReaderDecorator sortJsonFileReaderDecorator = new SortJsonFileReaderDecorator(jsonFileReader);
            IDictionary<string, string> jsonData = sortJsonFileReaderDecorator.ReadJsonFileData(filePath);
            
            foreach (var data in jsonData)
            {
                this._configuration.Data.Add(data.Key, data.Value);
            }

            return this;
        }

        public ConfigurationBuilder AddXmlFileData(string filePath)
        {
            //read xml file
            this._configuration.Data.Add("xml", "xml content");
            return this;
        }

        public MConfiguration Build()
        {
            return this._configuration;
        }
    }
}
