using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotifyService
    {
        void AddNotify(Notify notify);
        void DeleteNotify(Notify notify);
        void UpdateNotify(Notify notify);
        List<Notify> GetNotifies();
        List<Notify> GetNotifies(Expression<Func<Notify, bool>> expression);
        Notify GetNotify(int id);
    }
}
