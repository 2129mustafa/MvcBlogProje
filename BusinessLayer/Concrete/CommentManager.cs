using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;
        Repository<Comment> repo = new Repository<Comment>();

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogId == id);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }

        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentId == id);   //find tek değer döndürür liste döndürmez.
            comment.CommentStatus = false;
             _commentDal.Update(comment);
        }

        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentId == id);   //find tek değer döndürür liste döndürmez.
            comment.CommentStatus = true;
             _commentDal.Update(comment);
        }

        public Comment GetById(int id)
        {
           return  _commentDal.GetById(id);
        }
        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
