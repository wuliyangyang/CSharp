﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.Factory
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine($"Draw a {this.GetType().Name}");
        }
    }
}