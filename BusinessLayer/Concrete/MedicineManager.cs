using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
    public class MedicineManager : IMedicineService
    {
        IMedicineDal _medicineDal;

        public MedicineManager(IMedicineDal medicineDal)
        {
            _medicineDal = medicineDal;
        }

        public void AddMedicine(Medicine medicine)
        {
            _medicineDal.Create(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            _medicineDal.Delete(medicine);
        }

        public Medicine GetMedicine(int id)
        {
            return _medicineDal.GetById(id);
        }

        public List<Medicine> GetMedicines()
        {
            return _medicineDal.GetAll();
        }

        public List<Medicine> GetMedicines(Expression<Func<Medicine, bool>> expression)
        {
            return _medicineDal.GetAll(expression);
        } 
        public List<Medicine> GetMedicinesWithProperties(Expression<Func<Medicine, bool>> expression)
        {
            return _medicineDal.GetMedicinesWithProperties();
        }

        public List<Medicine> GetMedicinesWithProperties()
        {
            return _medicineDal.GetMedicinesWithProperties();
        }

        public Medicine GetMedicineWithProperties(int id)
        {
            return _medicineDal.GetMedicinewithProperties(id);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            _medicineDal.Update(medicine);
        }
    }
}
