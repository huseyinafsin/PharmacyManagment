using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EntityLayer.Concrete

{
    public partial class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int TotalAmount { get; set; }
        public int? UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
