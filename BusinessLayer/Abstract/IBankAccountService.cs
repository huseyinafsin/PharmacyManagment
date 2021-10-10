using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Abstract
{
    public interface IBankAccountService
    {
        IResult AddBankAccount(BankAccount bankAccount);
        IResult DeleteBankAccount(BankAccount bankAccount);
        IResult UpdateBankAccount(BankAccount bankAccount);
        IDataResult<List<BankAccount>> GetBankAccounts(Expression<Func<BankAccount, bool>> expression=null);
        IDataResult<BankAccount> GetBankAccount(int accountId);
    }
}
