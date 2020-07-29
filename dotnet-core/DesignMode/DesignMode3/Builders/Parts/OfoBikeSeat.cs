using DesignMode3.Builders.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders.Parts
{
    public class OfoBikeSeat : ISeat
    {
        public OfoBikeSeat()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
