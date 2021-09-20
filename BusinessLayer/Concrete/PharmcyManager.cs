using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PharmcyManager : IPharmacyService
    {
        private readonly EFPharmacyRepository eFPharmacyRepository;

        public PharmcyManager()
        {
            eFPharmacyRepository = new EFPharmacyRepository();
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            _ = eFPharmacyRepository.Create(pharmacy);
        }

        public void DeletePharmacy(Pharmacy pharmacy)
        {
            _ = eFPharmacyRepository.Delete(pharmacy);
        }

        public async Task<IQueryable<Pharmacy>> GetPharmacies()
        {
            return await eFPharmacyRepository.GetAll();
        }

        public List<Pharmacy> GetPharmacies(Expression<Func<Pharmacy, bool>> expression)
        {
            return eFPharmacyRepository.GetAll(expression).ToList();
        }

        public Pharmacy GetPharmacy(int id)
        {
            return eFPharmacyRepository.GetById(id).Result;
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            _ = eFPharmacyRepository.Update(pharmacy);
        }



      
    
   
        public List<ApplicationUser> GetUsers(int id)
        {
            var users = eFPharmacyRepository
                .GetAll().Result
                .Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u => u.Id == id).Result.ApplicationUsers.ToList();

            return users;
        }

       public void AssignUser(int pharmacyId, int appUserID)
        {
            using var context = new AppDBContext();

            var users = eFPharmacyRepository
                .GetAll().Result
                .Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();

            var user = context.ApplicationUsers.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit == false)
            {
                context.Pharmacies.Include(u => u.ApplicationUsers)
                        .FirstOrDefault(p => p.Id == pharmacyId).ApplicationUsers.Add(user);
                context.SaveChanges();
            }
        }

       public void RemoveUser(int pharmacyId, int appUserID)
        {
            using var _context = new AppDBContext();
            var users = eFPharmacyRepository
                .GetAll().Result
                .Include(u => u.ApplicationUsers)
                .FirstOrDefaultAsync(u => u.Id == pharmacyId).Result.ApplicationUsers.ToList();
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == appUserID);

            bool isExit = users.Contains(user);

            if (isExit == true)
            {
                _context.Pharmacies.Include(u => u.ApplicationUsers)
                        .FirstOrDefault(p => p.Id == pharmacyId).ApplicationUsers.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
