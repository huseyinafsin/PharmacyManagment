using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManufacturerService
    {
        void AddManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        List<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
    }
}
