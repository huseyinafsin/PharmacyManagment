using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void AddCustomer(Customer customer)
        {
            _customerDal.Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public  List<Customer> GetCustomers()
        {
            return  _customerDal.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _customerDal.GetById(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public List<Customer> GetCustomers(Expression<Func<Customer, bool>> expression)
        {
            return _customerDal.GetAll(expression).ToList();
        }

        public List<Customer> GetCustomersWithAddress()
        {
           return _customerDal.GetCustomersWithAddress();
        }
    }
}
