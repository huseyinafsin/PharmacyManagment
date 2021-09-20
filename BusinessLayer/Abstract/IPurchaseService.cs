using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPurchaseService
    {
        void AddPurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
       Task<IQueryable<Purchase>> GetPurchases();
        List<Purchase> GetPurchases(Expression<Func<Purchase, bool>> expression);
        Purchase GetPurchase(int id);
    }
}
