using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Pharmacy
    {


        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
