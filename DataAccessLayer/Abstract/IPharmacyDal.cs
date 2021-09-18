
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IPharmacyDal : IGenericDal<Pharmacy>
    {

        public List<ApplicationUser> GetUsers(int id);

        public void AssignUser(int pharmacyId, int appUserID);
        public void RemoveUser(int pharmacyId, int appUserID);


    }
}
