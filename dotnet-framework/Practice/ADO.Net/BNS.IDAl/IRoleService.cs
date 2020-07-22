using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNS.Model;

namespace BNS.IDAl
{
    public interface IRoleService
    {
        int Insert(BNSRole role);
        BNSRole Query(int id);
        BNSRole Query(string name);
        int Delete(int id);
        bool IsExist(string name);
    }
}
