using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMedicineTypeService
    {
        void AddMedicineType(MedicineType medicineType);
        void DeleteMedicineType(MedicineType medicineType);
        void UpdateMedicineType(MedicineType medicineType);
        List<MedicineType> GetMedicineTypes();
        MedicineType GetMedicineType(int id);
    }
}
