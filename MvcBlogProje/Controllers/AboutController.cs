﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{   
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            var aboutcontent = aboutManager.GetList();
            return View(aboutcontent);
        }

        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            var aboutcontentlist= aboutManager.GetList();
            return PartialView(aboutcontentlist);
        }
        [AllowAnonymous]
        public PartialViewResult MeatTheTeam()
        {
            var authorlist = authorManager.GetList();
            return PartialView(authorlist);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = aboutManager.GetList();
            return View(aboutlist);
        }

        [HttpPost]
        public ActionResult UpdateAboutList(About p)
        {
            aboutManager.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }

      
    }
}