using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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

        public async Task<IQueryable<Manufacturer>> GetManufacturers()
        {
            return await  eFManufacturerRepository.GetAll();
        }

        public List<Manufacturer> GetManufacturers(Expression<Func<Manufacturer, bool>> expression)
        {
            return eFManufacturerRepository.GetAll(expression).ToList();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _ = eFManufacturerRepository.Update(manufacturer);
        }
    }
}
