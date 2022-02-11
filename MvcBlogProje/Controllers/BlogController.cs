using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());
        Context c = new Context();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var bloglist = blogManager.GetList().ToPagedList(page, 6);
            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //1.post
            var posttitle1 = blogManager.GetList().OrderByDescending(z=>z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;

            //2.post
            var posttitle2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;

            //3.post
            var posttitle3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;

            //4.post
            var posttitle4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();
            
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;

            //5.post
            var posttitle5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId ==4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();
           
            ViewBag.posttitle5= posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;

            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = blogManager.GetBlogByCategory(id);

            var CategoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDescription = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;

            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var bloglist = blogManager.GetList();
            return View(bloglist);
        }

        public ActionResult AdminBlogList2()
        {
            var bloglist = blogManager.GetList();
            return View(bloglist);
        }

        [Authorize(Roles ="A")]
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            blogManager.TDelete(blog);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
          
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }

        public ActionResult AuthorBlogList(int id)
        {
            var blogs = blogManager.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}