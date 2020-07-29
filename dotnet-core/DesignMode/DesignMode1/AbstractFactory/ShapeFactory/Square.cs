using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ShapeFactory
{
    public class Square : IShape
    {
        public void Do()
        {
            Draw();
        }

        public void Draw()
        {
            Console.WriteLine($"Draw a {this.GetType().Name}");
        }
    }
}
