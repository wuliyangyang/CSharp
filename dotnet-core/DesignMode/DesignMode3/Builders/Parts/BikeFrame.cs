using DesignMode3.Builders.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders.Parts
{
    public class BikeFrame:IFrame
    {
        public BikeFrame()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
