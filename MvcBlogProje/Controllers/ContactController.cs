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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            ValidationResult results = contactValidator.Validate(c);
            if (results.IsValid)
            {
                c.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactManager.TAdd(c);
                return RedirectToAction("Index");
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

        public ActionResult SendBox()
        {
            var messagelist = contactManager.GetList();
            return View(messagelist);
        }

        public PartialViewResult PartialBox()
        {
            return PartialView();
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetById(id);
            return View(contact);
        }
    }
}