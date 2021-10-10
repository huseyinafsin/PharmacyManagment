using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccessLayer.Abstract
{
    public interface IManufacturerDal: IEntityRepository<Manufacturer>
    {
        List<Manufacturer>  GetManufacturersWithDetails(Expression<Func<Manufacturer, bool>> expression = null);
        Manufacturer GetSingleManufacturerWithDetails(Expression<Func<Manufacturer, bool>> expression);
    }
}
