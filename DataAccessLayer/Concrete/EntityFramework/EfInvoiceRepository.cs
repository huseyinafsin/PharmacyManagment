using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfInvoiceRepository : EfEntityRepositoryBase<Invoice, PharmacyManagmentContext>, IInvoiceDal
    {
        public List<Invoice> GetInvoicesWithDetails(Expression<Func<Invoice, bool>> expression = null)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return expression == null
                    ? context.Invoices
                        .Include(x => x.Customer)
                        .Include(x => x.Medicines)
                        .Include(x => x.User)
                        .ToList()
                    : context.Invoices
                        .Include(x => x.Customer)
                        .Include(x => x.Medicines)
                        .Include(x => x.User)
                        .Where(expression)
                        .ToList();

            }
        }

        public Invoice GetSingleInvoiceWithDetails(Expression<Func<Invoice, bool>> expression)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return context.Invoices
                    .Include(x => x.Customer)
                    .Include(x => x.Medicines)
                    .Include(x => x.User)
                    .SingleOrDefault(expression);
            }
        }
    }
}
