using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            
            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (userinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail;
                return RedirectToAction("Index", "User");
            }
            else
            {
               return  RedirectToAction("AuthorLogin", "Login");
            }
          
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admininfo!=null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName;
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}