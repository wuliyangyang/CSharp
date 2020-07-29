using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory
{
    interface IFactory
    {
        MAbstractFactory GetFactory(string factory);
    }
}
