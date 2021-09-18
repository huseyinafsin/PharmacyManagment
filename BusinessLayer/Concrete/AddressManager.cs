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
    public class AddressManager : IAddressService
    {
        EFAddressRepository eFAddressRepository;

        public AddressManager()
        {
            eFAddressRepository = new EFAddressRepository();
        }

        public void AddAddress(Address address)
        {
            _ = eFAddressRepository.Create(address);
        }

        public void DeleteAddress(Address address)
        {
            _ = eFAddressRepository.Delete(address);
        }

        public Address GetAddress(int id)
        {
            return eFAddressRepository.GetById(id).Result;
        }

        public List<Address> GetAddresses()
        {
           return eFAddressRepository.GetAll().ToList();
        }

        public void UpdateAddress(Address address)
        {
            _ = eFAddressRepository.Update(address);
        }
    }
}
