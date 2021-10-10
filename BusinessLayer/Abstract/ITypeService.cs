using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
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
