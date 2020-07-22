using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Interface;
namespace YY.Service
{
    public class Power : IPower
    {
        public Power()
        {
            Console.WriteLine("Power is structured");
        }
        public void PowerOn()
        {
            Console.WriteLine("PowerOn");
        }
    }
}
