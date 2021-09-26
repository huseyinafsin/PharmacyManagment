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
    public class UnitManager : IUnitService
    {

        IUnitDal _unitDal;

        public UnitManager(IUnitDal unitDal)
        {
            _unitDal = unitDal;
        }

        public void AddUnit(Unit unit)
        {
            _unitDal.Create(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _unitDal.Delete(unit);
        }

        public Unit GetUnit(int id)
        {
            return _unitDal.GetById(id);
        }

        public List<Unit> GetUnites()
        {
            return _unitDal.GetAll();
        }

        public List<Unit> GetUnites(Expression<Func<Unit, bool>> expression)
        {
            return _unitDal.GetAll(expression);
        }

        public void UpdateUnit(Unit unit)
        {
             _unitDal.Update(unit);
        }
    }
}
