using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Builders.Interface
{
   public  interface IBuilder
    {
        Bike BuildBike();
        void Assembly();
    }
}
