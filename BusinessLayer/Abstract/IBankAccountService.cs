using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBankAccountService
    {
        void AddBankAccount(BankAccount bankAccount);
        void DeleteBankAccount(BankAccount bankAccount);
        void UpdateBankAccount(BankAccount bankAccount);
        List<BankAccount> GetBankAccounts();
        List<BankAccount> GetBankAccounts(Expression<Func<BankAccount, bool>> expression);
        BankAccount GetBankAccount(int id);
    }
}
