using System.Web;
using System.Web.Mvc;
using YY.SOA.WebApi.Controllers;

namespace YY.SOA.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
