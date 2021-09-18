using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        BankAccount GetBankAccount(int id);
    }
}
