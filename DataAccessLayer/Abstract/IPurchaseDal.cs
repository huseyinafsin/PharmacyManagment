using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;


namespace DataAccessLayer.Abstract
{
    public interface IPurchaseDal :IEntityRepository<Purchase>
    {
        List<Purchase> GetPurchasesWithDetails(Expression<Func<Purchase, bool>> expression = null);
        Purchase GetSinglePurchaseWithDetails(Expression<Func<Purchase, bool>> expression);
    }
}
