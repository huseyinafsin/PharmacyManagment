using BusinessLayer.Abstract;
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
    public class CustomerManager : ICustomerService
    {
        EFCustomerRepository eFCustomerManager;

        public CustomerManager()
        {
            eFCustomerManager = new EFCustomerRepository();
        }

        public void AddCustomer(Customer customer)
        {
            _ = eFCustomerManager.Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _ = eFCustomerManager.Delete(customer);
        }

        public  async Task<IQueryable<Customer>> GetCustomers()
        {
            return await eFCustomerManager.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return eFCustomerManager.GetById(id).Result;
        }

        public void UpdateCustomer(Customer customer)
        {
            _ = eFCustomerManager.Update(customer);
        }

        public List<Customer> GetCustomers(Expression<Func<Customer, bool>> expression)
        {
            return eFCustomerManager.GetAll(expression).ToList();
        }
    }
}
