using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EFManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerDal

    {
      
        public List<Manufacturer> GetManufacturers()
        {
            using var _context = new AppDBContext();
            return _context.Manufacturers.Include(m => m.BankAccount).Include(m => m.Medicines).ToList();
        }
    }
}
