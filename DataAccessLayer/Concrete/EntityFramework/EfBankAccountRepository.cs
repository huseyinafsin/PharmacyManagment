using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBankAccountRepository : EfEntityRepositoryBase<BankAccount, PharmacyManagmentContext>, IBankAccountDal
    {
      
    }
}
