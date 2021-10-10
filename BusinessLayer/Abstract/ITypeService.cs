using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface ITypeService
    {
        IResult AddType(MedicineType medicineType);
        IResult DeleteType(MedicineType medicineType);
        IResult UpdateType(MedicineType medicineType);
        IDataResult<List<MedicineType>> GetTypes(Expression<Func<MedicineType, bool>> expression=null);
        IDataResult<MedicineType> GetType(int typeId);
    }
}
