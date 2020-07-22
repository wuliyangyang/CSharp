using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YY.SOA.WebApi.Controllers
{
    [CustomAllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public String Login()
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, "yy", DateTime.Now,DateTime.Now.AddHours(1), true, "yy", FormsAuthentication.FormsCookiePath);
            var ret = new
            {
                Result = true,
                Ticket = ticket,
            };

            return JsonConvert.SerializeObject(ret);
            ;
        }
    }
}
