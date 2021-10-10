using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IManufacturerService
    {
        IResult AddManufacturer(Manufacturer manufacturer);
        IResult DeleteManufacturer(Manufacturer manufacturer);
        IResult UpdateManufacturer(Manufacturer manufacturer);
        IDataResult<List<Manufacturer>> GetManufacturersWithDetails(Expression<Func<Manufacturer, bool>> expression = null);
        IDataResult<List<Manufacturer>> GetManufacturers(Expression<Func<Manufacturer, bool>> expression=null);
        IDataResult<Manufacturer> GetManufacturer(int manufacturerId);
        IDataResult<Manufacturer> GetSingleManufacturerWithDetails(int manufacturerId);
    }
}
