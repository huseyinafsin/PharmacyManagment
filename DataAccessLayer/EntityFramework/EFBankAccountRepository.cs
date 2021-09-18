using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework
{
    public class EFBankAccountRepository : GenericRepository<BankAccount>, IBankAccountDal
    {
      

        public void Deducate(BankAccount account, string accountType, int quantity)
        {
            if (accountType.ToLowerInvariant()=="credit")
            {
                
            }
            else if (accountType.ToLowerInvariant()=="balance")
            {

            }
            else
            {
                throw new Exception("Wrong account type");
            }
        }

        public BankAccount GetBankAccount()
        {
            using var _context = new AppDBContext();
            BankAccount bankAccount = new BankAccount();
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();
            return bankAccount;
        }

    }
}
