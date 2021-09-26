using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerDal
    {

        public List<Manufacturer> GetManufacturersWithProperties()
        {
            using var c = new AppDBContext();
            return c.Manufacturers
                .Include(x => x.Address)
                .Include(X=>X.BankAccount)
                .Include(x=>x.Medicines)
                .Include(x=>x.Notifies)
                .ToList();
    }

        public Manufacturer GetManufacturerWithProperties(int id)
        {
            using var c = new AppDBContext();
            return c.Manufacturers
                .Include(x => x.Address)
                .Include(X => X.BankAccount)
                .Include(x => x.Medicines)
                .Include(x => x.Notifies)
                .FirstOrDefault(x=>x.ManufacturerId==id);
        }
    }
}
