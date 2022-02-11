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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var values = categoryManager.GetList();
            return PartialView(values);
        }

        public ActionResult AdminCategoryList()
        {
            var posttitle1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var posttitle2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var posttitle3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var posttitle4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var posttitle5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var posttitle6 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogTitle).FirstOrDefault();

            var categorylist = categoryManager.GetList();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.posttitle2 = posttitle2;
            ViewBag.posttitle3 = posttitle3;
            ViewBag.posttitle4 = posttitle4;
            ViewBag.posttitle5 = posttitle5;
            ViewBag.posttitle6 = posttitle6;
            return View(categorylist);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.TAdd(p);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult CategoryEdit(int id)
        {

            Category category = categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.TUpdate(p);
                return RedirectToAction("AdminCategoryList");
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

        public ActionResult CategoryStatusFalse(int id)
        {
            categoryManager.CategoryStatusFalseBL(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult CategoryStatusTrue(int id)
        {
            categoryManager.CategoryStatusTrueBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}