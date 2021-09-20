using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUnitService
    {
        void AddUnit(Unit unit);
        void DeleteUnit(Unit unit);
        void UpdateUnit(Unit unit);
        Task<IQueryable<Unit>> GetUnites();
        List<Unit> GetUnites(Expression<Func<Unit, bool>> expression);
        Unit GetUnit(int id);
    }
}
