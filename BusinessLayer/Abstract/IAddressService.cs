using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        void UpdateAddress(Address address);
        Task<IQueryable<Address>> GetAddresses();
        List<Address> GetAddresses(Expression<Func<Address, bool>> expression);

        Address GetAddress(int id);
    }
} 
