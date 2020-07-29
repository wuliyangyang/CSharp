using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ShapeFactory
{
    public class MShapeFactory: MAbstractFactory
    {
        public override IObject GetT(string name)
        {
            if (name.Equals("Circle"))
            {
                return new Circle();
            }
            else if(name.Equals("Square"))
            {
                return new Square();
            }
            else if (name.Equals("Rectangle"))
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
