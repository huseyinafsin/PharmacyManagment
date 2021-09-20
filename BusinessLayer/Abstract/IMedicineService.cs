using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMedicineService
    {
        void AddMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        Task<IQueryable<Medicine>> GetMedicines();
        List<Medicine> GetMedicines(Expression<Func<Medicine, bool>> expression);
        Medicine GetMedicine(int id);
    }
}
