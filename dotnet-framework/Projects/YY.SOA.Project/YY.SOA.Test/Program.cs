using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.WCF.Interface;
using YY.WCF.Models;
using YY.WCF.Service;

namespace YY.SOA.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFServiceInit.Process();
        }
    }
}
