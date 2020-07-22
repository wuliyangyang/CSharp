using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YY.AspNetCore.WebDemo.Models;
using YY.AspNetCore.WebDemo.Utility.ConsulHelper;
using YY.AspNetCore.WebDemo.Utility.WebAipExtend;
using Microsoft.Extensions.Configuration;
using YY.AspNetCore.WebDemo.Utility.Filters;
using Microsoft.AspNetCore.Authorization;

namespace YY.AspNetCore.WebDemo.Controllers
{
    //[TypeFilter(typeof(CustomAuthorizeActionFilterAttribute))]//使用TypeFilter是因为 CustomAuthorizeActionFilterAttribute 里面有依赖注入
    //[TypeFilter(typeof(CustomGlobalActionFilterAttribute))]//使用TypeFilter是因为 CustomAuthorizeActionFilterAttribute 里面有依赖注入

    //[Authorize]
    [ResponseCache(Duration =100)]//中间件 缓存
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        
        public IActionResult Index()
        {
            _logger.LogInformation("Home Index");
            return View();
        }
        public IActionResult  Privacy()
        {
            return View();
        }

        public IActionResult Test(int id)
        {
            string url = ConsulHelper.GetUrlByRoundrobin();
            url = url + $"id/{id}";
            string data = WebApiHelper.InvokeApi(url);
            _logger.LogInformation(url);
            //return View();
            return new JsonResult(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
