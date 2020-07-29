using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Configuration.Interface
{
    public abstract class AbstractJsonFileReader
    {
        protected IJsonFileReader _jsonFileReader;

        public AbstractJsonFileReader(IJsonFileReader jsonFileReader)
        {
            this._jsonFileReader = jsonFileReader;
        }

    }
}
