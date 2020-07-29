using DesignMode1.AbstractFactory.ColorFactory;
using DesignMode1.AbstractFactory.ShapeFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory
{
    class FactoryProducter : IFactory
    {
       public MAbstractFactory GetFactory(string factory)
        {
            if (factory.Equals("shape"))
            {
                return new MShapeFactory();
            }
            else if (factory.Equals("color"))
            {
                return new MColorFactory();
            }
            else
                return null;
        }
    }
}
