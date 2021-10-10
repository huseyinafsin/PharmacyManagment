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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IResult AddAddress(Address address)
        {
            //Bussiness rules here
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
        }

        public IResult DeleteAddress(Address address)
        {
            _addressDal.Delete(address);
             return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<Address> GetAddress(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(x=>x.AddressId==id),Messages.AddressFetched);
        }


        public IDataResult<List<Address>> GetAddresses(Expression<Func<Address, bool>> expression)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(expression),Messages.AddressListed);
        }


        public IResult UpdateAddress(Address address)
        { 
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
    }
}
