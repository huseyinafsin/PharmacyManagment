using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfLeafRepository: EfEntityRepositoryBase<Leaf, PharmacyManagmentContext>, ILeafDal
    {
    }
}
