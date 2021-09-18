using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Unit> GetUnites()
        {
            return eFUnitRepository.GetAll().ToList();
        }

        public void UpdateUnit(Unit unit)
        {
            _ = eFUnitRepository.Update(unit);
        }
    }
}
