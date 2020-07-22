using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YY.Framework;
using YY.Web.Core;
using YY.MVC5.Filter;

namespace YY.MVC5.Controllers
{
    [CustomAllow]
    [CustomActionFilterAttribute]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password, string verify)
        {
            var Name = base.HttpContext.Request.Form["Name"];
            verify = base.HttpContext.Session["CheckCode"].ToString();
            if (verify.Equals(base.HttpContext.Session["CheckCode"].ToString()))
            {
                if ("yy".Equals(name) && "1".Equals(password))
                {
                    CurrentUser currentUser = new CurrentUser()
                    {
                        Name = name,
                        Password = password,
                        LoginTime = DateTime.Now
                    };
                    base.HttpContext.Session["CurrentUser"] = currentUser;
                    if (base.HttpContext.Session["CurrentUrl"] != null)
                    {
                        string url = base.HttpContext.Session["CurrentUrl"].ToString();
                        base.HttpContext.Session.Remove("CurrentUrl");
                        return Redirect(url);
                    }
                    return Redirect("~/ImageName/Index");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            base.HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;//Session识别用户，为单一用户有效
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return new FileContentResult(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }

        /// <summary>
        /// 验证码  直接写入Response
        /// </summary>
        public void Verify()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }
    }
}