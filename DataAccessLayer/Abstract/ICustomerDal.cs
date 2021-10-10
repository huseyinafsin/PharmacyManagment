using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;


namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<Customer> GetCustomersWithDetails(Expression<Func<Customer, bool>> expression = null);
        Customer GetSingleCustomerWithDetails(Expression<Func<Customer, bool>> expression );

    }
}
