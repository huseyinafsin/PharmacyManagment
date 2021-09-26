using System;
using System.Collections.Generic;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerEmail { get; set; }
        public int MnufacturerPhone { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public bool ManufacturerStatus { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }

    }
}
