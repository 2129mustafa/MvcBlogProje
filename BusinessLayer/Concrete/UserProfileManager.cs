using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repo = new Repository<Author>();
        Repository<Blog> repoblog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repo.List(x => x.Mail == p);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x => x.AuthorId == id);
        }

        public void EditAuthor(Author p)
        {
            Author author = repo.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorName = p.AuthorName;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorImage = p.AuthorImage;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            author.Mail = p.Mail;

             repo.Update(author);
        }

    }
}
