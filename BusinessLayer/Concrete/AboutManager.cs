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
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;
        Repository<About> repoblog = new Repository<About>();

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
