using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class MedicineType : BaseEntity
    {
        public MedicineType()
        {
            Medicines = new HashSet<Medicine>();
        }


        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
