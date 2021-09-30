using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void AddAddress(Address address)
        {
             _addressDal.Create(address);
        }

        public void DeleteAddress(Address address)
        {
             _addressDal.Delete(address);
        }

        public Address GetAddress(int id)
        {
            return _addressDal.GetById(id);
        }

        public List<Address> GetAddresses()
        {
            return  _addressDal.GetAll();
        }

        public List<Address> GetAddresses(Expression<Func<Address, bool>> expression)
        {
            return _addressDal.GetAll(expression).ToList();
        }

        public void UpdateAddress(Address address)
        {
             _addressDal.Update(address);
        }
    }
}
