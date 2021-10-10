using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EfBankAccountRepository : EfEntityRepositoryBase<BankAccount, PharmacyManagmentContext>, IBankAccountDal
    {
      
    }
}
