﻿using System;
using System.Collections.Generic;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Manufacturer : BaseEntity
    {
        public Manufacturer()
        {
            Medicines = new HashSet<Medicine>();
            Notifies = new HashSet<Notify>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public int Fax { get; set; }

        public virtual Address Address { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Notify> Notifies { get; set; }

    }
}
