using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace EntityLayer.Concrete
{
    public class Pharmacy: IEntity
    {

        [Key]
        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string PhoneNumber { get; set; }
        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
