using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Data
{
    public class Pharmacy : BaseEntity
    {

        public  string Name { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public  virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
