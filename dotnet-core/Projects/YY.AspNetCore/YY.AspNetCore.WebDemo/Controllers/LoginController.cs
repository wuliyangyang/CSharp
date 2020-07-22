using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using YY.Framework;
using YY.Framework.SessionExt;
using YY.Web.Core;
using YY.AspNetCore.WebDemo.Utility.Filters;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace YY.AspNetCore.WebDemo.Controllers
{

    [CustomAllowFilter]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password, string verify)
        {
            var Name = base.HttpContext.Request.Form["Name"];
             string cacheVerify = base.HttpContext.Session.GetString("CheckCode");
            verify = cacheVerify;
            if (cacheVerify != null && cacheVerify.Equals(verify, StringComparison.CurrentCultureIgnoreCase))
            {
                if ("yy".Equals(name) && "1".Equals(password))
                {
                    CurrentUser currentUser = new CurrentUser()
                    {
                        Name = name,
                        Password = password,
                        LoginTime = DateTime.Now,
                        Account="123456",
                        Email="YY@YY.COM"
                    };
                    _logger.LogInformation($"{currentUser.Name} 已经登录。。。");
                    #region 基于filter
                    base.HttpContext.Session.SetObject("CurrentUser", currentUser);
                    string currentUrl = base.HttpContext.Session.GetString("CurrentUrl");
                    if (currentUrl != null)
                    {
                        string url = currentUrl;
                        base.HttpContext.Session.Remove("CurrentUrl");
                        return Redirect(url);
                    }
                    #endregion

                    #region 基于系统自带的cookie
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,name),
                        new Claim("password",password),//可以写入任意数据
                    };
                    var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30),//过期时间
                    }).Wait();//没用await
                    ////cookie策略--用户信息---过期时间
                    #endregion

                    return base.Redirect("~/Home/Index");
                }
                else
                {
                    ViewBag.Msg = "账号密码错误";
                }
            }
            else
            {
                ViewBag.Msg = "验证码错误";
            }
            return View();
        }
        public ActionResult Logout()
        {
            //base.HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return Redirect("~/Home/Index");
        }


        [HttpGet]
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode",code);//Session识别用户，为单一用户有效
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return new FileContentResult(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }

        [HttpGet]
        public void Verify()   // 验证码  直接写入Response
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode",code);
            bitmap.Save(base.Response.Body, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }
    }
}