using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using DataAccessLayer.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class BankAccountManager : IBankAccountService
    {
        private readonly IBankAccountDal _bankAccountDal;

        public BankAccountManager(IBankAccountDal bankAccountDal)
        {
            _bankAccountDal = bankAccountDal;
        }

        public IResult AddBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Add(bankAccount);
            return new SuccessResult(Messages.BankAccountAdded);
        }

        public IResult DeleteBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Delete(bankAccount);
            return new SuccessResult(Messages.BankAccountDeleted);
        }

        public IDataResult<BankAccount> GetBankAccount(int id)
        {
           return new SuccessDataResult<BankAccount>(_bankAccountDal.Get(x=>x.AccoıuntId==id),Messages.BankAccountFetched);
        }

  
        public IDataResult<List<BankAccount>> GetBankAccounts(Expression<Func<BankAccount, bool>> expression)
        {
            return new SuccessDataResult<List<BankAccount>>(_bankAccountDal.GetAll(expression),Messages.BankAccountListed);
        }


        public IResult UpdateBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Update(bankAccount);
            return new SuccessResult(Messages.BankAccountUpdated);
        }
    }
}
