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

        public List<Customer> GetCustomers()
        {
            return eFCustomerManager.GetAll().ToList();
        }

        public Customer GetCustomer(int id)
        {
            return eFCustomerManager.GetById(id).Result;
        }

        public void UpdateCustomer(Customer customer)
        {
            _ = eFCustomerManager.Update(customer);
        }
    }
}
