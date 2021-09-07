using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;
using PharmacyManagmentV2.Repositories;

namespace PharmacyManagmentV2.Repositories
{
    public class ApplicationUserPharmacyRepository : GenericRepository<ApplicationUserPharmacy>, IApplicationUserPharmacyRepository
    {
        internal AppDBContext _context;
        public ApplicationUserPharmacyRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationUserPharmacy GetAsFiltered(Expression<Func<ApplicationUserPharmacy, bool>> filter)
        {

            return _context.ApplicationUserPharmacies.FirstOrDefault(filter);
        }
    }
}
