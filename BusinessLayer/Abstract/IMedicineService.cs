using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMedicineService
    {
        void AddMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        List<Medicine> GetMedicines();
        Medicine GetMedicine(int id);
    }
}
