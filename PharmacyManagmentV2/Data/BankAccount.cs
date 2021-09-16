﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Data
{
    public class BankAccount:BaseEntity
    {
   
        public long AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public int Balance { get; set; }
        public int CreditLine { get; set; }
        public bool IsTaken { get; set; }

    }
}
