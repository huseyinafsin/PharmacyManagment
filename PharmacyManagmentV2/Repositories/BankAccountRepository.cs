using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Repositories
{
    public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
    {
        private readonly AppDBContext _context;
        public BankAccountRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }



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
            BankAccount bankAccount = new BankAccount();
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();
            return bankAccount;
        }

    }
}
