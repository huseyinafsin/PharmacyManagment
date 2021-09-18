using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PharmcyManager : IPharmacyService
    {

        EFPharmacyRepository eFPharmacyRepository;

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

        public List<Pharmacy> GetPharmacies()
        {
            return eFPharmacyRepository.GetAll().ToList();
        }

        public Pharmacy GetPharmacy(int id)
        {
            return eFPharmacyRepository.GetById(id).Result;
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            _ = eFPharmacyRepository.Update(pharmacy);
        }
    }
}
