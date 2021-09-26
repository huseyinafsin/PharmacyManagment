using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace EntityLayer.Concrete
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public override int Id  { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public override  string  PhoneNumber { get; set; }
        public int UserType { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public bool UserStatus { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Invoice> Sells { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }
    }
}
