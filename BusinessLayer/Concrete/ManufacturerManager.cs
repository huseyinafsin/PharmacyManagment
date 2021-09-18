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
    public class ManufacturerManager : IManufacturerService
    {
        EFManufacturerRepository eFManufacturerRepository;

        public ManufacturerManager()
        {
            eFManufacturerRepository = new EFManufacturerRepository();
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            _ = eFManufacturerRepository.Create(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _ = eFManufacturerRepository.Delete(manufacturer);
        }

        public Manufacturer GetManufacturer(int id)
        {
            return eFManufacturerRepository.GetById(id).Result;
        }

        public List<Manufacturer> GetManufacturers()
        {
            return eFManufacturerRepository.GetAll().ToList();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _ = eFManufacturerRepository.Update(manufacturer);
        }
    }
}
