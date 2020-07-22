using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.WebApi.Interface;

namespace YY.WebApi.Service
{
    public class UserService : IUserService
    {
        public object Query(int id)
        {
            return new
            {
                Id = id,
                Name = "yy",
                Age = 18,
            };
        }
    }
}
