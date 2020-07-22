using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMQTest
{
    public delegate void PostMsgHandler(object sender, string msg);
    public delegate void RecvMsgHandler(object sender, string msg);
    class DataModel
    {
    }
}
