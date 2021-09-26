using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EntityLayer.Concrete

{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        public int TotalAmount { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
