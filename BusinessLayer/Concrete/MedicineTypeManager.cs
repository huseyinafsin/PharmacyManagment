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

        public List<MedicineType> GetMedicineTypes()
        {
            return eFMedicineTypeRepository.GetAll().ToList();
        }

        public void UpdateMedicineType(MedicineType medicineType)
        {
            _ = eFMedicineTypeRepository.Update(medicineType);
        }
    }
}
