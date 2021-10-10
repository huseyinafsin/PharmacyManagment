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
    public interface IUnitService
    {
        IResult AddUnit(Unit unit);
        IResult DeleteUnit(Unit unit);
        IResult UpdateUnit(Unit unit);
        IDataResult<List<Unit>> GetUnites(Expression<Func<Unit, bool>> expression=null);
        IDataResult<Unit> GetUnit(int unitId);
    }
}
