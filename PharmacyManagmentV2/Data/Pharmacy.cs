using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Data
{
    public class Pharmacy : BaseEntity
    {
        public Pharmacy()
        {
            Medicines = new HashSet<Medicine>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public  string Name { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
