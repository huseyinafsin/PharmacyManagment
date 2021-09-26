using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITypeService
    {
        void AddType(MedicineType medicineType);
        void DeleteType(MedicineType medicineType);
        void UpdateType(MedicineType medicineType);
        List<MedicineType> GetTypes();
        List<MedicineType> GetTypes(Expression<Func<MedicineType, bool>> expression);
        MedicineType GetType(int id);
    }
}
