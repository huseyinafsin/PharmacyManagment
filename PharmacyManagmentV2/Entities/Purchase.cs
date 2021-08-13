using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class Purchase : BaseEntity
    {

        public Purchase()
        {
            Medicines = new HashSet<Medicine>();
        }
        public int BoxQty { get; set; }
        public int TotalAmount { get; set; }
        public string AppUserId { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
