﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ColorFactory
{
    public class Blue : IColor
    {
        public void Do()
        {
            Fill();
        }

        public void Fill()
        {
            Console.WriteLine($"Fill {this.GetType().Name}");
        }
    }
}