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
    public class EfManufacturerRepository : EfEntityRepositoryBase<Manufacturer, PharmacyManagmentContext>, IManufacturerDal
    {
        public List<Manufacturer> GetManufacturersWithDetails(Expression<Func<Manufacturer, bool>> expression = null)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return expression == null
                    ? context.Manufacturers
                        .Include(x => x.BankAccount)
                        .Include(x => x.Address)
                        .Include(x => x.Medicines)
                        .Include(x => x.Notifies)
                        .ToList()
                    : context.Manufacturers
                        .Include(x => x.BankAccount)
                        .Include(x => x.Address)
                        .Include(x => x.Medicines)
                        .Include(x => x.Notifies)
                        .Where(expression).ToList();
            }
        }

        public Manufacturer GetSingleManufacturerWithDetails(Expression<Func<Manufacturer, bool>> expression)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return context.Manufacturers
                    .Include(x => x.BankAccount)
                    .Include(x => x.Address)
                    .Include(x => x.Medicines)
                    .Include(x => x.Notifies)
                    .SingleOrDefault(expression);
            }
        }
    }
}
