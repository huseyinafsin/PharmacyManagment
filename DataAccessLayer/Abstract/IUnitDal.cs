using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace DataAccessLayer.Abstract
{
    public interface IUnitDal : IEntityRepository<Unit>
    {
    }
}
