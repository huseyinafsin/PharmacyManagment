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
    public class EfPharmacyRepository : EfEntityRepositoryBase<Pharmacy, PharmacyManagmentContext>, IPharmacyDal
    {
        public List<Pharmacy> GetPharmaciesWithDetails(Expression<Func<Pharmacy, bool>> expression = null)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return expression == null
                    ? context.Pharmacies
                        .Include(x => x.BankAccount)
                        .Include(x => x.ApplicationUsers)
                        .Include(x => x.Medicines)
                        .Include(x => x.Address)
                        .ToList()
                    : context.Pharmacies
                        .Include(x => x.BankAccount)
                        .Include(x => x.ApplicationUsers)
                        .Include(x => x.Medicines)
                        .Include(x => x.Address)
                        .Where(expression)
                        .ToList();
            }
        }

        public Pharmacy GetSinglePharmacyWithDetails(Expression<Func<Pharmacy, bool>> expression)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return context.Pharmacies
                    .Include(x => x.BankAccount)
                    .Include(x => x.ApplicationUsers)
                    .Include(x => x.Medicines)
                    .Include(x => x.Address)
                    .SingleOrDefault(expression);
            }
   
        }
    }
}
