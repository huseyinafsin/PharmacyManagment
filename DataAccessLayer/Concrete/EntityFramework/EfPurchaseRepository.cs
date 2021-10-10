using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPurchaseRepository : EfEntityRepositoryBase<Purchase, PharmacyManagmentContext>, IPurchaseDal
    {
        public List<Purchase> GetPurchasesWithDetails(Expression<Func<Purchase, bool>> expression = null)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return expression == null
                    ? context.Purchases
                        .Include(x => x.Medicines)
                        .Include(x => x.AppUser)
                        .Include(x => x.Medicines)
                        .ToList()
                    : context.Purchases
                        .Include(x => x.Medicines)
                        .Include(x => x.AppUser)
                        .Include(x => x.Medicines)
                        .Where(expression)
                        .ToList();
            }
        }

        public Purchase GetSinglePurchaseWithDetails(Expression<Func<Purchase, bool>> expression)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext() )
            {
                return context.Purchases
                    .Include(x => x.Medicines)
                    .Include(x => x.AppUser)
                    .Include(x => x.Medicines)
                    .SingleOrDefault(expression);
            }
        }
    }
}
