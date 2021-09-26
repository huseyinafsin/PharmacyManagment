using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        IPharmacyDal _pharmacyDal;

        public PharmcyManager(IPharmacyDal pharmacyDal)
        {
            _pharmacyDal = pharmacyDal;
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Create(pharmacy);
        }

        public void DeletePharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Delete(pharmacy);
        }

        public List<Pharmacy> GetPharmacies()
        {
            return _pharmacyDal.GetAll();
        }

        public List<Pharmacy> GetPharmacies(Expression<Func<Pharmacy, bool>> expression)
        {
            return _pharmacyDal.GetAll(expression);
        }

        public List<Pharmacy> GetPharmaciesWithBankAccount()
        {
            return _pharmacyDal.GetPharmaciesWithBankAccount();
        }

        public Pharmacy GetPharmacy(int id)
        {
            return _pharmacyDal.GetById(id);
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            _pharmacyDal.Update(pharmacy);
        }
    }
}
