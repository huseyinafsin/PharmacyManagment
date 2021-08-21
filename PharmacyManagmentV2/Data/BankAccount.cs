using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Data
{
    public class BankAccount:BaseEntity
    {
        public int Balance { get; set; }
        public int CreditLine { get; set; }

        public int OwnerId { get; set; }
    }
}
