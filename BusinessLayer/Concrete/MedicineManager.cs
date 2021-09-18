using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MedicineManager : IMedicineService
    {
        EFMedicineRepository eFMedicineRepository;

        public MedicineManager()
        {
            eFMedicineRepository = new EFMedicineRepository();
        }

        public void AddMedicine(Medicine medicine)
        {
            _ = eFMedicineRepository.Create(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            _ = eFMedicineRepository.Delete(medicine);
        }

        public Medicine GetMedicine(int id)
        {
            return eFMedicineRepository.GetById(id).Result;
        }

        public List<Medicine> GetMedicines()
        {
            return eFMedicineRepository.GetAll().ToList();
        }

        public void UpdateMedicine(Medicine medicine)
        {
            _ = eFMedicineRepository.Update(medicine);
        }
    }
}
