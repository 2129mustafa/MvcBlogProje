using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProje.Controllers
{
    public class UserController : Controller
    {  
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context c = new Context();
        public ActionResult Index()
        {   
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            

            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            blogManager.TAdd(b);
            return RedirectToAction("BlogList");
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

    }
}