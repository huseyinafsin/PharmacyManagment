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
        public List<Pharmacy> GetPharmaciesWithBankAccount()
        {
            using var c = new AppDBContext();

            return c.Pharmacies.Include(x => x.BankAccount).ToList();
        }

        public List<Pharmacy> GetPharmaciesWithUsers()
        {
            using var c = new AppDBContext();
            return c.Pharmacies.Include(x => x.ApplicationUsers).ToList();
        }
    }
}
