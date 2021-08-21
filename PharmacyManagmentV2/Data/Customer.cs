using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Data
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Sells = new HashSet<Invoice>();
        }

      
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBird { get; set; }
        public int Phone { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Invoice> Sells { get; set; }
    }
}
