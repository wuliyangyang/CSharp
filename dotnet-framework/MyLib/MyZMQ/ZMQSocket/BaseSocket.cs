using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZMQ
{
    public class BaseSocket
    {
        public BaseSocket()
        {
            Name = "ZMQ";
        }
        
        public string Name { get; set; }
    }
}
