using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Interface;
namespace YY.Service
{
    public class Display : IDisplay
    {
        public Display()
        {
            Console.WriteLine("Display is structured");
        }
        public void DisplayOn()
        {
            Console.WriteLine("DisplayOn");
        }
    }
}
