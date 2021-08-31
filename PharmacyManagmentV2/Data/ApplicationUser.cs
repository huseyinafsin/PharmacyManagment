using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Data
{
    public partial class ApplicationUser: IdentityUser<int>
    {
        public ApplicationUser()
        {
            Purchases = new HashSet<Purchase>();
            Sells = new HashSet<Invoice>();
            Notifies = new HashSet<Notify>();
            
        }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public override  string  PhoneNumber { get; set; }
        public string UserType { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Invoice> Sells { get; set; }
        public virtual ICollection<Notify>? Notifies { get; set; }
    }
}
