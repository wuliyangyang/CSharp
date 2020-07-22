using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using BNS.Model;
using BNS.DAL;
using BNS.IDAl;

namespace BNS.BLL
{
    public class RoleServiceBLL
    {
         IRoleService service;
        public RoleServiceBLL()
        {
             service = new RoleServiceDAL();
        }
        public void Insert(BNSRole role)
        {
            if (service.IsExist(role.SName))
                Console.WriteLine("{0}:名字已经存在,请换个名字！！", role.SName);
            else
                service.Insert(role);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public BNSRole Query(int id)
        {
            return service.Query(id);
        }
        public BNSRole Query(string name)
        {
            return service.Query(name);
        }
    }
}
