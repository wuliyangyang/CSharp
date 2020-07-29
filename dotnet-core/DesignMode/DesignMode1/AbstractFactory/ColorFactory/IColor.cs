using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory.ColorFactory
{
    public interface IColor: IObject
    {
        void Fill();
    }
}
