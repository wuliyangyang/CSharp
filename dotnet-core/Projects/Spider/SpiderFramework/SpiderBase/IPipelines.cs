using System;
using System.Collections.Generic;
using System.Text;

namespace SpiderBase
{
    public interface IPipelines
    {
        void ProcessItem(IBaseModel model);
    }
}
