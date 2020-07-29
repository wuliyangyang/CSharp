using DesignMode3.Builders.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders.Parts
{
    public class BikeTire:ITire
    {
        public BikeTire()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
