using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;


namespace DataAccessLayer.Abstract
{
    public interface IBankAccountDal : IEntityRepository<BankAccount>
    {
       
    }   
}
