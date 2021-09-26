using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PurchaseManager : IPurchaseService
    {

        IPurchaseDal _purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }

        public void AddPurchase(Purchase purchase)
        {
             _purchaseDal.Create(purchase);
        }

        public void DeletePurchase(Purchase purchase)
        {
            _purchaseDal.Delete(purchase);
        }

        public Purchase GetPurchase(int id)
        {
            return _purchaseDal.GetById(id);
        }

        public List<Purchase> GetPurchases()
        {
            return _purchaseDal.GetAll();
        }

        public List<Purchase> GetPurchases(Expression<Func<Purchase, bool>> expression)
        {
            return _purchaseDal.GetAll(expression).ToList();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            _purchaseDal.Update(purchase);
        }
    }
}
