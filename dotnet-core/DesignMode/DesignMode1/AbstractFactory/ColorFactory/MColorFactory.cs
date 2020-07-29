using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ColorFactory
{
    public class MColorFactory: MAbstractFactory
    {
        public override IObject GetT(string name)
        {
            if (name.Equals("Red"))
            {
                return new Red();
            }
            else if (name.Equals("Blue"))
            {
                return new Blue();
            }
            else if (name.Equals("Green"))
            {
                return new Green();
            }
            else
            {
                return null;
            }
        }
    }
}
