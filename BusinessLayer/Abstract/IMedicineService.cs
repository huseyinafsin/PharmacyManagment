using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IMedicineService
    {
        IResult AddMedicine(Medicine medicine);
        IResult DeleteMedicine(Medicine medicine);
        IResult UpdateMedicine(Medicine medicine);
        IDataResult<List<Medicine>> GetMedicinesWithDetails(Expression<Func<Medicine, bool>> expression = null);
        IDataResult<List<Medicine>> GetMedicines(Expression<Func<Medicine, bool>> expression=null);
        IDataResult<Medicine> GetMedicine(int medicineId);
        IDataResult<Medicine> GetSingleMedicineWithDetails(int medicineId);
    }
}
