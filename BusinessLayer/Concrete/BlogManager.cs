using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager:IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AuthorId == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x => x.CategoryId == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void TAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void TDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void TUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
