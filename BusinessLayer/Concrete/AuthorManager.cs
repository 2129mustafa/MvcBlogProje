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
    public class AuthorManager:IAuthorService
    {
        IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        Repository<Author> repo = new Repository<Author>();
        //tüm yazar listesini getirme
        public List<Author> GetList()
        {
            return repo.List();
        }

        public Author GetById(int id)
        {
            return repo.GetById(id);
        }

        public void TAdd(Author t)
        {
            _authorDal.Insert(t);
        }

        public void TDelete(Author t)
        {
            _authorDal.Delete(t);
        }

        public void TUpdate(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
