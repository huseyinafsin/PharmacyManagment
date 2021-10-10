using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class NotifyManager : INotifyService
    {
       // INotifyDal not implemented

        public IResult AddNotify(Notify notify)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteNotify(Notify notify)
        {
            throw new NotImplementedException();
        }



        public IDataResult<List<Notify>> GetNotifies(Expression<Func<Notify, bool>> expression)
        {
            throw new NotImplementedException();
        }



        public IDataResult<Notify> GetNotify(int id)
        {
            throw new NotImplementedException();
        }



        public IResult UpdateNotify(Notify notify)
        {
            throw new NotImplementedException();
        }

    
    }
}
