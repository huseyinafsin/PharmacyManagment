using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotifyManager : INotifyService
    {

        public void AddNotify(Notify notify)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotify(Notify notify)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Notify>> GetNotifies()
        {
            throw new NotImplementedException();
        }

        public List<Notify> GetNotifies(Expression<Func<Notify, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Notify GetNotify(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNotify(Notify notify)
        {
            throw new NotImplementedException();
        }

        List<Notify> INotifyService.GetNotifies()
        {
            throw new NotImplementedException();
        }
    }
}
