
using System.Collections.Generic;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Interfaces
{
    public interface IPharmacyRepository : IGenericRepository<Pharmacy>
    {


        public List<ApplicationUser> GetUsers(int id);

        public void AssignUser(int pharmacyId, int appUserID);
        public void RemoveUser(int pharmacyId, int appUserID);


    }
}
