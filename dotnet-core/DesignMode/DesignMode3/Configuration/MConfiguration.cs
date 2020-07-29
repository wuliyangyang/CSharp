using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration
{
    public class MConfiguration
    {
        public IDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        public void Set(string key,string value)
        {
            this.Data.Add(key, value);
        }

        /// <summary>
        /// 索引取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                if (Data.ContainsKey(key)) return Data[key];
                else return null;

            }
        }
    }
}
