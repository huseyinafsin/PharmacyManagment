using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Data
{
    public partial class Address:BaseEntity
    {
        public Address()
        {
            AspNetUsers = new HashSet<ApplicationUser>();
            Customers = new HashSet<Customer>();
            Manufacturers = new HashSet<Manufacturer>();
        }

        public string City{ get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public virtual ICollection<ApplicationUser> AspNetUsers { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }



    }
}
