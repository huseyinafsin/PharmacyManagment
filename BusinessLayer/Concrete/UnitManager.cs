using BusinessLayer.Abstract;
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

        EFUnitRepository eFUnitRepository;

        public UnitManager()
        {
            eFUnitRepository = new EFUnitRepository();
        }

        public void AddUnit(Unit unit)
        {
            _ = eFUnitRepository.Create(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _ = eFUnitRepository.Delete(unit);
        }

        public Unit GetUnit(int id)
        {
            return eFUnitRepository.GetById(id).Result;
        }

        public async Task<IQueryable<Unit>> GetUnites()
        {
            return await eFUnitRepository.GetAll();
        }

        public List<Unit> GetUnites(Expression<Func<Unit, bool>> expression)
        {
            return eFUnitRepository.GetAll(expression).ToList();
        }

        public void UpdateUnit(Unit unit)
        {
            _ = eFUnitRepository.Update(unit);
        }
    }
}
