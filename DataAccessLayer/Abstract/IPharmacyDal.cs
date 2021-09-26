
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IPharmacyDal : IGenericDal<Pharmacy>
    {

        List<Pharmacy> GetPharmaciesWithBankAccount();   
        List<Pharmacy> GetPharmaciesWithUsers();   


    }
}
