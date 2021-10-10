using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class TypeManager : ITypeService
    {

        private readonly ITypeDal _typeDal;

        public TypeManager(ITypeDal typeDal)
        {
            _typeDal = typeDal;
        }

        public IResult AddType(MedicineType type)
        {
            _typeDal.Add(type);
            return new SuccessResult(Messages.TypeAdded);
        }

        public IResult DeleteType(MedicineType type)
        {
            _typeDal.Delete(type);
            return new SuccessResult(Messages.TypeDeleted);
        }


        public IDataResult<MedicineType> GetType(int id)
        {
            return new SuccessDataResult<MedicineType>( _typeDal.Get(x => x.TypeId == id), Messages.TypeFetched);
        }


        public IDataResult<List<MedicineType>> GetTypes(Expression<Func<MedicineType, bool>> expression)
        {
            return new SuccessDataResult<List<MedicineType>>( _typeDal.GetAll(expression), Messages.TypeListed);
        }


        public IResult UpdateType(MedicineType medicineType)
        {
            _typeDal.Update(medicineType);
            return new SuccessResult(Messages.TypeUpdated);
        }

       
    }
}
