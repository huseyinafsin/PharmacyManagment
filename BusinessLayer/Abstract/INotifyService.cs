using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface INotifyService
    {
        IResult AddNotify(Notify notify);
        IResult DeleteNotify(Notify notify);
        IResult UpdateNotify(Notify notify);
        IDataResult<List<Notify>> GetNotifies(Expression<Func<Notify, bool>> expression=null);
        IDataResult<Notify> GetNotify(int notifyId);
    }
}
