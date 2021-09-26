using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ManufacturerManager : IManufacturerService
    {
        IManufacturerDal _manufacturerDal;

        public ManufacturerManager(IManufacturerDal manufacturerDal)
        {
            _manufacturerDal = manufacturerDal;
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDal.Create(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDal.Delete(manufacturer);
        }

        public List<Manufacturer> GetManufacturers()
        {
           return _manufacturerDal.GetAll();
        }

        public List<Manufacturer> GetManufacturers(Expression<Func<Manufacturer, bool>> expression)
        {
            return _manufacturerDal.GetAll(expression);
        }

        public List<Manufacturer> GetManufacturersWithProperties()
        {
            return _manufacturerDal.GetManufacturersWithProperties();
        }

        public Manufacturer GetManufacturerWithPropeties(int id)
        {
            return _manufacturerDal.GetManufacturerWithProperties(id);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            return _manufacturerDal.Update(manufacturer);
        }
    }
}
