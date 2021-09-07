using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;

namespace PharmacyManagmentV2.Interfaces
{
    public interface IApplicationUserPharmacyRepository : IGenericRepository<ApplicationUserPharmacy>
    {
       public ApplicationUserPharmacy GetAsFiltered(Expression<Func<ApplicationUserPharmacy, bool>> filter);

    }

}
