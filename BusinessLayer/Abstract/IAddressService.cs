using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IAddressService
    {
        IResult AddAddress(Address address);
        IResult DeleteAddress(Address address);
        IResult UpdateAddress(Address address);
        IDataResult<List<Address>> GetAddresses(Expression<Func<Address, bool>> expression=null);
        IDataResult<Address> GetAddress(int addressId);
    }
} 
