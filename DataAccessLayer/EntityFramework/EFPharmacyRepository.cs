using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EFPharmacyRepository : GenericRepository<Pharmacy>, IPharmacyDal
    {


    List<ApplicationUser> IPharmacyDal.GetUsers(int pharmacyId)
    {

            using var _context = new AppDBContext();
            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u=>u.Id==pharmacyId).Result.ApplicationUsers.ToList();

            return users;
    }


    void IPharmacyDal.AssignUser(int pharmacyId, int appUserID)
    {
            using var _context = new AppDBContext();
            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit==false)
            {
            _context.Pharmacies.Include(u=>u.ApplicationUsers)
                    .FirstOrDefault(p=>p.Id==pharmacyId).ApplicationUsers.Add(user);
            _context.SaveChanges();
            }
            
    }

     void IPharmacyDal.RemoveUser(int pharmacyId, int appUserID)
        {
            using var _context = new AppDBContext();
            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                      .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit ==true)
            {
                _context.Pharmacies.Include(u => u.ApplicationUsers)
                        .FirstOrDefault(p => p.Id == pharmacyId).ApplicationUsers.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<ApplicationUser> GetUsers(int id)
        {
            throw new NotImplementedException();
        }

        public void AssignUser(int pharmacyId, int appUserID)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int pharmacyId, int appUserID)
        {
            throw new NotImplementedException();
        }
    }
}
