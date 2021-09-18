using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using DataAccessLayer.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BankAccountManager : IBankAccountService
    {
        EFBankAccountRepository eFBankAccountManager;

        public BankAccountManager()
        {
            eFBankAccountManager = new EFBankAccountRepository();
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            _ = eFBankAccountManager.Create(bankAccount);
        }

        public void DeleteBankAccount(BankAccount bankAccount)
        {
            _ = eFBankAccountManager.Delete(bankAccount);
        }

        public BankAccount GetBankAccount(int id)
        {
           return eFBankAccountManager.GetById(id).Result;
        }

        public List<BankAccount> GetBankAccounts()
        {
            return eFBankAccountManager.GetAll().ToList();
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            _ = eFBankAccountManager.Update(bankAccount);
        }
    }
}
