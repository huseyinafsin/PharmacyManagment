using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccessLayer.Abstract
{
    public interface IBankAccountDal : IGenericDal<BankAccount>
    {
        void Deducate(BankAccount account, string accountType, int quantity);
        BankAccount GetBankAccount();
    }
}
