using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PurchaseManager : IPurchaseService
    {

        EFPurchaseRepository eFPurchaseRepository;

        public PurchaseManager()
        {
            eFPurchaseRepository = new EFPurchaseRepository();
        }

        public void AddPurchase(Purchase purchase)
        {
            _ = eFPurchaseRepository.Create(purchase);
        }

        public void DeletePurchase(Purchase purchase)
        {
            _ = eFPurchaseRepository.Delete(purchase);
        }

        public Purchase GetPurchase(int id)
        {
            return eFPurchaseRepository.GetById(id).Result;
        }

        public List<Purchase> GetPurchases()
        {
            return eFPurchaseRepository.GetAll().ToList();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            _ = eFPurchaseRepository.Update(purchase);
        }
    }
}
