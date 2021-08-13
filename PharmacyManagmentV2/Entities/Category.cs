using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class Category :BaseEntity
    {
        public Category()
        {
            Medicines = new HashSet<Medicine>();
        }
     
        public int Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
