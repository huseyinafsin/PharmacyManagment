using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IPurchaseService
    {
        IResult AddPurchase(Purchase purchase);
        IResult DeletePurchase(Purchase purchase);
        IResult UpdatePurchase(Purchase purchase);
        IDataResult<List<Purchase>> GetPurchasesWithDetails(Expression<Func<Purchase, bool>> expression = null);
        IDataResult<List<Purchase>> GetPurchases(Expression<Func<Purchase, bool>> expression=null);
        IDataResult<Purchase> GetPurchase(int purchaseId);
        IDataResult<Purchase> GetSinglePurchaseWithDetails(int purchaseId);
    }
}
