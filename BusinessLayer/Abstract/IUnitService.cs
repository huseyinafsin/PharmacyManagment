using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUnitService
    {
        void AddUnit(Unit unit);
        void DeleteUnit(Unit unit);
        void UpdateUnit(Unit unit);
        List<Unit> GetUnites();
        Unit GetUnit(int id);
    }
}
