using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration.Interface
{
    public interface IJsonFileReader
    {
        IDictionary<string, string> ReadJsonFileData(string jsonFilePath);
    }
}
