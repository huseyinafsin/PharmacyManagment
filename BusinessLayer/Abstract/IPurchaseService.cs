using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPurchaseService
    {
        void AddPurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        List<Purchase> GetPurchases();
        Purchase GetPurchase(int id);
    }
}
