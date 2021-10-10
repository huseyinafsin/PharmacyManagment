using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;


namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<Customer> GetCustomersWithDetails(Expression<Func<Customer, bool>> expression = null);
        Customer GetSingleCustomerWithDetails(Expression<Func<Customer, bool>> expression );

    }
}
