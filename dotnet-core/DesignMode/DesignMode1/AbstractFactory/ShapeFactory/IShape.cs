using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ShapeFactory
{
   public interface IShape: IObject
    {
        void Draw();
    }
}
