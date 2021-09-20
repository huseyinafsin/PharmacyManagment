using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMedicineTypeService
    {
        void AddMedicineType(MedicineType medicineType);
        void DeleteMedicineType(MedicineType medicineType);
        void UpdateMedicineType(MedicineType medicineType);
        Task<IQueryable<MedicineType>> GetMedicineTypes();
        List<MedicineType> GetMedicineTypes(Expression<Func<MedicineType, bool>> expression);
        MedicineType GetMedicineType(int id);
    }
}
