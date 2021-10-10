using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);

        }


        public IDataResult<Customer> GetCustomer(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == id), Messages.CustomerFetched);
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);

        }

        public IDataResult<List<Customer>> GetCustomers(Expression<Func<Customer, bool>> expression)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(expression), Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetCustomersWithDetails(Expression<Func<Customer, bool>> expression = null)
        {
            //DTO Query
            return new SuccessDataResult<List<Customer>>(_customerDal.GetCustomersWithDetails(expression), Messages.CustomerListed);
        }

        public IDataResult<Customer> GetSingleCustomerWithDetails(int customerId)
        {
            //DTO Query
            return new SuccessDataResult<Customer>(
                _customerDal.GetSingleCustomerWithDetails(x => x.CustomerId == customerId), Messages.CustomerListed);
        }
    }
}
