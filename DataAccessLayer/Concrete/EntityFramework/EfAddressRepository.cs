using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAddressRepository : EfEntityRepositoryBase<Address, PharmacyManagmentContext>, IAddressDal
    {
       
    }
}
