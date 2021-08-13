using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class ApplicationUser: IdentityUser<int>
    {
        public ApplicationUser()
        {
            
            Purchases = new HashSet<Purchase>();
            Sells = new HashSet<Sell>();
        }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
    }
}
