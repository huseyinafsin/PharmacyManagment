using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManufacturerService
    {
        void AddManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        Task<IQueryable<Manufacturer>> GetManufacturers();
        List<Manufacturer> GetManufacturers(Expression<Func<Manufacturer, bool>> expression);
        Manufacturer GetManufacturer(int id);
    }
}
