using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Interface;

namespace YY.Service
{
    public class MacBook : AbstractCommputer,IComputer
    {
        public MacBook(IPower power,IDisplay display)
        {

        }
        public void PlayGame()
        {
            Console.WriteLine("MacBook Play Game");
        }
    }
}
