using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPharmacyService
    {
        void AddPharmacy(Pharmacy pharmacy);
        void DeletePharmacy(Pharmacy pharmacy);
        void UpdatePharmacy(Pharmacy pharmacy);
        List<Pharmacy> GetPharmacies();
        Pharmacy GetPharmacy(int id);
    }
}
