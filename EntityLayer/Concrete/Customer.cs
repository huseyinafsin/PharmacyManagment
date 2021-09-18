using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Sells = new HashSet<Invoice>();
            Notifies = new HashSet<Notify>();
        }

      
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBird { get; set; }
        public int Phone { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Invoice> Sells { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }

    }
}
