﻿using EntityLayer.Concrete;
using Core.DataAccess;


namespace DataAccessLayer.Abstract
{
    public interface IBankAccountDal : IEntityRepository<BankAccount>
    {
       
    }   
}
