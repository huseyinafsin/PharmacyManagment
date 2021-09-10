using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;

namespace PharmacyManagmentV2.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        private readonly AppDBContext _context;
        public ManufacturerRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Manufacturer> GetManufacturers()
        {
           return  _context.Manufacturers.Include(m => m.BankAccount).Include(m => m.Medicines).ToList();
        }
    }
}
