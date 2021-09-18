using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFPurchaseRepository : GenericRepository<Purchase>, IPurchaseDal
    {

        public List<Pharmacy> GetPharmacies()
        {
            using var _context = new AppDBContext();
            throw new NotImplementedException();
        }
    }
}
