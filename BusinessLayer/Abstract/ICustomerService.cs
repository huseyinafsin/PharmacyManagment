using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IDataResult<List<Customer>> GetCustomersWithDetails(Expression<Func<Customer, bool>> expression = null);
        IDataResult<List<Customer>> GetCustomers(Expression<Func<Customer, bool>> expression=null);
        IDataResult<Customer> GetSingleCustomerWithDetails(int customerId);
        IDataResult<Customer> GetCustomer(int customerId);

    }
}
