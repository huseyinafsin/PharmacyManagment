using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        void UpdateAddress(Address address);
        List<Address> GetAddresses();
        Address GetAddress(int id);
    }
} 
