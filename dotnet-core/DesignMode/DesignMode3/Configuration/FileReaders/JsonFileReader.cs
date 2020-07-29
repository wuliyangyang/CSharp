using DesignMode3.Configuration.Decorators;
using DesignMode3.Configuration.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration.FileReaders
{
    public class JsonFileReader : IJsonFileReader
    {
        public IDictionary<string, string> ReadJsonFileData(string jsonFilePath)
        {
            //1.读取jsonfile

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("json", "json content");

            return data;
        }
    }
}
