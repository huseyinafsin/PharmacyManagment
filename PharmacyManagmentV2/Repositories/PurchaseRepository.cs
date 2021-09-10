using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        private readonly AppDBContext _context;
             public PurchaseRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

       

        public List<Pharmacy> GetPharmacies()
        {
            throw new NotImplementedException();
        }
    }
}
