using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.Factory
{
    public class ShapeFactory
    {
        public static IShape GetShape(string shape)
        {
            if (shape.Equals("Circle"))
            {
                return new Circle();
            }
            else if(shape.Equals("Square"))
            {
                return new Square();
            }
            else if (shape.Equals("Rectangle"))
            {
                return new Rectangle();
            }
            else
            {
                return null;
            }
        }
    }
}
