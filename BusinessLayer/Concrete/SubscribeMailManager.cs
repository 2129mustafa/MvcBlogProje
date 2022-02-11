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
    public class SubscribeMailManager:IMailService
    {
        IMailDal _mailDal;
        Repository<SubscribeMail> reposubscribemail = new Repository<SubscribeMail>();

        public SubscribeMailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public SubscribeMail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public List<SubscribeMail> GetList()
        {
            return _mailDal.List();
        }

        public void TAdd(SubscribeMail t)
        {
            _mailDal.Insert(t);
        }

        public void TDelete(SubscribeMail t)
        {
            _mailDal.Delete(t);
        }

        public void TUpdate(SubscribeMail t)
        {
            _mailDal.Update(t);
        }
    }
}
