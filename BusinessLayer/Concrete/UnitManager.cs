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
    public class UnitManager : IUnitService
    {

        private  readonly IUnitDal _unitDal;

        public UnitManager(IUnitDal unitDal)
        {
            _unitDal = unitDal;
        }

        public IResult AddUnit(Unit unit)
        {
            _unitDal.Add(unit);
            return new SuccessResult(Messages.UnitAdded);
        }

        public IResult DeleteUnit(Unit unit)
        {
            _unitDal.Delete(unit);
            return new SuccessResult(Messages.UnitDeleted);
        }


        public IDataResult<Unit> GetUnit(int id)
        {
            return new SuccessDataResult<Unit>( _unitDal.Get(x=>x.UnitId==id), Messages.UnitFetched);
        }


        public IDataResult<List<Unit>> GetUnites(Expression<Func<Unit, bool>> expression)
        {
            return new SuccessDataResult<List<Unit>>( _unitDal.GetAll(expression), Messages.UnitListed);
        }


        public IResult UpdateUnit(Unit unit)
        {
             _unitDal.Update(unit);
             return new SuccessResult(Messages.UnitUpdated);
        }
    }
}
