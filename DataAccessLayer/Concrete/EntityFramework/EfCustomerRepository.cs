using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerRepository : EfEntityRepositoryBase<Customer,PharmacyManagmentContext>, ICustomerDal
    {
        public List<Customer> GetCustomersWithDetails(Expression<Func<Customer, bool>> expression = null)
        {
            using (PharmacyManagmentContext context= new PharmacyManagmentContext())
            {
                return expression == null
                    ?
                    context.Customers
                    .Include(x => x.Address)
                    .Include(x => x.BankAccount)
                    .Include(x => x.Invoices)
                    .Include(x => x.Notifies)
                    .ToList()
                    : context.Customers
                    .Include(x => x.Address)
                    .Include(x => x.BankAccount)
                    .Include(x => x.Invoices)
                    .Include(x => x.Notifies)
                    .Where(expression)
                    .ToList();

            }
        }

        public Customer GetSingleCustomerWithDetails(Expression<Func<Customer, bool>> expression)
        {
            using (PharmacyManagmentContext context = new PharmacyManagmentContext())
            {
                return
                    context.Customers
                        .Include(x => x.Address)
                        .Include(x => x.BankAccount)
                        .Include(x => x.Invoices)
                        .Include(x => x.Notifies)
                        .SingleOrDefault(expression);

            }
        }
    }
}
