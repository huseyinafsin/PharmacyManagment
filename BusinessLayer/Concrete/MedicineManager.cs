using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class MedicineManager : IMedicineService
    {
        private readonly IMedicineDal _medicineDal;

        public MedicineManager(IMedicineDal medicineDal)
        {
            _medicineDal = medicineDal;
        }

        public IResult AddMedicine(Medicine medicine)
        {
            _medicineDal.Add(medicine);
            return new SuccessResult(Messages.MedicineAdded);
        }

        public IResult DeleteMedicine(Medicine medicine)
        {
            _medicineDal.Delete(medicine);
            return new SuccessResult(Messages.MedicineDeleted);
        }

        public IDataResult<Medicine> GetMedicine(int id)
        {
            return new SuccessDataResult<Medicine>( _medicineDal.Get(x => x.MedicineId == id),Messages.MedicineFetched);
        }


        public IDataResult<List<Medicine>> GetMedicines(Expression<Func<Medicine, bool>> expression)
        {
            return new SuccessDataResult<List<Medicine>>( _medicineDal.GetAll(expression),Messages.MedicineListed);
        }

        public IDataResult<List<Medicine>> GetMedicinesWithDetails(Expression<Func<Medicine, bool>> expression = null)
        {
            //DTO Query
            return new SuccessDataResult<List<Medicine>>(_medicineDal.GetMedicinesWithDetails(expression), Messages.MedicineListed);
        }

        public IDataResult<Medicine> GetSingleMedicineWithDetails(int medicineId)
        {
            //DTO Query
            return new SuccessDataResult<Medicine>(_medicineDal.GetSingleMedicineWithDetails(x=>x.MedicineId==medicineId),
                Messages.MedicineFetched);
        }

        public IResult UpdateMedicine(Medicine medicine)
        {
            _medicineDal.Update(medicine);
            return new SuccessResult(Messages.MedicineUpdated);

        }
    }
}
