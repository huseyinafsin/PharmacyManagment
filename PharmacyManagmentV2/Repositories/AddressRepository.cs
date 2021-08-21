using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;
using PharmacyManagmentV2.Repositories;

namespace PharmacyManagmentV2.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDBContext context) : base(context)
        {
        }

        public Task Create(Address obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Address obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Address obj)
        {
            throw new NotImplementedException();
        }

        IQueryable<Address> IGenericRepository<Address>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Address> IGenericRepository<Address>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
