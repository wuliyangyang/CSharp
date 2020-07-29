using DesignMode3.Configuration.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration.Decorators
{
    public class SortJsonFileReaderDecorator :AbstractJsonFileReader ,IJsonFileReader
    {
        //private IJsonFileReader _jsonFileReader;

        public SortJsonFileReaderDecorator(IJsonFileReader jsonFileReader):base(jsonFileReader)
        {
           //this._jsonFileReader = jsonFileReader;
        }
        public IDictionary<string, string> ReadJsonFileData(string jsonFilePath)
        {
            IDictionary<string, string> data =  _jsonFileReader.ReadJsonFileData(jsonFilePath);

            return Sort(data);
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IDictionary<string, string> Sort(IDictionary<string, string> data)
        {
            //排序
            Console.WriteLine("Sort");
            SortedDictionary<string, string> keyValuePairs = new SortedDictionary<string, string>();
            foreach (var item in data)
            {
                keyValuePairs.Add(item.Key, item.Value);
            }
            return keyValuePairs;
        }
    }
}
