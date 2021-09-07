using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;

namespace PharmacyManagmentV2.Repositories
{
    public class PharmacyRepository : GenericRepository<Pharmacy>, IPharmacyRepository
    {

        private readonly AppDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PharmacyRepository(AppDBContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;

        }



    List<ApplicationUser> IPharmacyRepository.GetUsers(int pharmacyId)
    {

            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u=>u.Id==pharmacyId).Result.ApplicationUsers.ToList();

            return users;
    }


    void IPharmacyRepository.AssignUser(int pharmacyId, int appUserID)
    {
            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();
            var user = _userManager.Users.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit==false)
            {
            _context.Pharmacies.Include(u=>u.ApplicationUsers)
                    .FirstOrDefault(p=>p.Id==pharmacyId).ApplicationUsers.Add(user);
            _context.SaveChanges();
            }
            
    }

     void IPharmacyRepository.RemoveUser(int pharmacyId, int appUserID)
        {
            var users = _context.Pharmacies.Include(u => u.ApplicationUsers)
                      .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();
            var user = _userManager.Users.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit ==true)
            {
                _context.Pharmacies.Include(u => u.ApplicationUsers)
                        .FirstOrDefault(p => p.Id == pharmacyId).ApplicationUsers.Remove(user);
                _context.SaveChanges();
            }
        }
}
}
