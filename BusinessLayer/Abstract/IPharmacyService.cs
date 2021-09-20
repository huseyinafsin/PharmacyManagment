using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPharmacyService
    {
        void AddPharmacy(Pharmacy pharmacy);
        void DeletePharmacy(Pharmacy pharmacy);
        void UpdatePharmacy(Pharmacy pharmacy);
        Task<IQueryable<Pharmacy>> GetPharmacies();
        List<Pharmacy> GetPharmacies(Expression<Func<Pharmacy, bool>> expression);
        Pharmacy GetPharmacy(int id);

        List<ApplicationUser> GetUsers(int id);
        void AssignUser(int pharmacyId, int appUserID);
        void RemoveUser(int pharmacyId, int appUserID);
    }
}
