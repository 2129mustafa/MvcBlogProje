using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        AuthorValidator authorValidator = new AuthorValidator();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogManager.GetBlogById(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogManager.GetList().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            //ViewBag.blogauthorid = blogauthorid;
            var authorblog = blogManager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblog);
        }

        public ActionResult AuthorList()
        {
            var authorlist = authorManager.GetList();
            return View(authorlist);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {        
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authorManager.TAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.GetById(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authorManager.TUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}