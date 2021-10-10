using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUnitRepository :EfEntityRepositoryBase<Unit,PharmacyManagmentContext>, IUnitDal
    {
    }
}
