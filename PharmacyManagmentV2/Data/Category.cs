using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Data
{
    public partial class Category :BaseEntity
    {
        public Category()
        {
            Medicines = new HashSet<Medicine>();
        }
     
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
