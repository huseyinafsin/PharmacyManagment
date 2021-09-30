using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public partial class Customer 
    {

        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerGender { get; set; }
        public DateTime DateofBird { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public string CustomerImage { get; set; }
        public bool CustomerStatus { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }

    }
}
