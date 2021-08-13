using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class Manufacturer : BaseEntity
    {
        public Manufacturer()
        {
            Medicines = new HashSet<Medicine>();
        }

      
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public int Fax { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
