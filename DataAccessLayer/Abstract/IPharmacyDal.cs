
using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccessLayer.Abstract
{
    public interface IPharmacyDal : IEntityRepository<Pharmacy>
    {
        List<Pharmacy> GetPharmaciesWithDetails(Expression<Func<Pharmacy, bool>> expression = null);
        Pharmacy GetSinglePharmacyWithDetails(Expression<Func<Pharmacy, bool>> expression);
    }
}
