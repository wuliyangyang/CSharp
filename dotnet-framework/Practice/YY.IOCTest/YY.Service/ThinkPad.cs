using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Interface;

namespace YY.Service
{
    public class ThinkPad : AbstractCommputer,IComputer
    {
        public void PlayGame()
        {
            Console.WriteLine("ThinkPad Play Game");
        }
    }
}
