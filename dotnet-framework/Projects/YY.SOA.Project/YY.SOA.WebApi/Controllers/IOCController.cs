using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YY.WebApi.Interface;
using YY.WebApi.Service;
using Unity;
using Newtonsoft;
using Newtonsoft.Json;

namespace YY.SOA.WebApi.Controllers
{
    [CustomAllowAnonymous]
    public class IOCController : ApiController
    {
        private IUserService userService = null;
        public IOCController(IUserService userService)
        {
            this.userService = userService;
         }
        public string GetUserById(int id)
        {
           // IUserService userService = ContainerFactory.GetContainer().Resolve<IUserService>();

            object ob = userService.Query(id);
            string userStr = JsonConvert.SerializeObject(ob);
            return userStr;
        }

        [Route("api/ioc/Id/{id:int}/Name/{name}")]
        public string GetUserByIdAndName(int id, string name)
        {
            object ob = userService.Query(id);
            string userStr = JsonConvert.SerializeObject(ob);
            return userStr;
        }
    }
}
