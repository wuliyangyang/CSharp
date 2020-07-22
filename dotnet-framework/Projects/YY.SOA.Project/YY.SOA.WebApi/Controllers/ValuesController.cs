using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YY.SOA.WebApi.Controllers
{
    //[RoutePrefix("api/values/")] 添加路由前缀
    //[Route("~api/values/{id:int}")] 去除某个方法的前缀
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/values/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/values/{id:int}/V2")]
        public string Get1(int id)
        {
            return "value2";
        }

        [Route("api/values/name/{name}")]
        [HttpGet]
        public string GetName(string name)
        {
            return "yangyang";
        }

        [Route("api/values/id/{id:int}/name/{name}")]
        public string GetStudent(int id, string name)
        {
            return "zhangsan";
        }
        // POST api/values
        public string Post([FromBody]string value)
        {
            return "post method "+ value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
