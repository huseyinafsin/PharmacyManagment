using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<IQueryable<Customer>> GetCustomers();
        List<Customer> GetCustomers(Expression<Func<Customer, bool>> expression);
        Customer GetCustomer(int id);
    }
}
