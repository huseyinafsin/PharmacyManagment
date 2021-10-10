using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IPharmacyService
    {
        IResult AddPharmacy(Pharmacy pharmacy);
        IResult DeletePharmacy(Pharmacy pharmacy);
        IResult UpdatePharmacy(Pharmacy pharmacy);
        IDataResult<List<Pharmacy>> GetPharmaciesWithDetails(Expression<Func<Pharmacy, bool>> expression = null);
        IDataResult<List<Pharmacy>> GetPharmacies(Expression<Func<Pharmacy, bool>> expression=null);
        IDataResult<Pharmacy> GetPharmacy(int pharmacyId);
        IDataResult<Pharmacy> GetSinglePharmacyWithDetails(int pharmacyId);

    }
}
