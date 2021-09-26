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

namespace BusinessLayer.Concrete
{
    public class BankAccountManager : IBankAccountService
    {
        private readonly IBankAccountDal _bankAccountDal;

        public BankAccountManager(IBankAccountDal bankAccountDal)
        {
            _bankAccountDal = bankAccountDal;
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Create(bankAccount);
        }

        public void DeleteBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Delete(bankAccount);
        }

        public BankAccount GetBankAccount(int id)
        {
           return _bankAccountDal.GetById(id);
        }

        public List<BankAccount> GetBankAccounts()
        {
            return _bankAccountDal.GetAll();
        }

        public List<BankAccount> GetBankAccounts(Expression<Func<BankAccount, bool>> expression)
        {
            return _bankAccountDal.GetAll(expression).ToList();
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            _bankAccountDal.Update(bankAccount);
        }
    }
}
