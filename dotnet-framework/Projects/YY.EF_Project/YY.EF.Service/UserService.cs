using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Interface;
using YY.EF.Model;

namespace YY.EF.Service
{
    public class UserService:BaseService,IUserService
    {
        public UserService(DbContext context) : base(context)
        {
           
        }
    }
}
