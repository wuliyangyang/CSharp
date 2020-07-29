using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.AbstractFactory
{
   public abstract class  MAbstractFactory
    {
      public  abstract IObject GetT(string name);
    }
}
