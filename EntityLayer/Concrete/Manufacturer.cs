using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Manufacturer: IEntity
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerEmail { get; set; }
        public int ManufacturerPhone { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public string ManufacturerLogo { get; set; }
        public bool ManufacturerStatus { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }

    }
}
