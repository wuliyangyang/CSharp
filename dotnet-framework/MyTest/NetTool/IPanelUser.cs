using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTool
{
    interface IPanelUser
    {
        event PostMsgHandler Evt_ActionStart;
        Model Model { get; }
       void MDispose();
    }
}
