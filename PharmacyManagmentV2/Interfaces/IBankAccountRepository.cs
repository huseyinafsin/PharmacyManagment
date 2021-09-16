using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Interfaces
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount>
    {
        void Deducate(BankAccount account, string accountType, int quantity);
        BankAccount GetBankAccount();
    }
}
