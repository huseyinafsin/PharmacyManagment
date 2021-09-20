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
    public class MedicineTypeManager : IMedicineTypeService
    {

        EFMedicineTypeRepository eFMedicineTypeRepository;

        public MedicineTypeManager()
        {
            eFMedicineTypeRepository = new EFMedicineTypeRepository();
        }

        public void AddMedicineType(MedicineType medicineType)
        {
            _ = eFMedicineTypeRepository.Create(medicineType);
        }

        public void DeleteMedicineType(MedicineType medicineType)
        {
            eFMedicineTypeRepository.Delete(GetMedicineType);
        }

        public MedicineType GetMedicineType(int id)
        {
            return eFMedicineTypeRepository.GetById(id).Result;
                
        }

        public async Task<IQueryable<MedicineType>> GetMedicineTypes()
        {
            return await    eFMedicineTypeRepository.GetAll();
        }

        public List<MedicineType> GetMedicineTypes(Expression<Func<MedicineType, bool>> expression)
        {
            return eFMedicineTypeRepository.GetAll(expression).ToList();
        }

        public void UpdateMedicineType(MedicineType medicineType)
        {
            _ = eFMedicineTypeRepository.Update(medicineType);
        }
    }
}
