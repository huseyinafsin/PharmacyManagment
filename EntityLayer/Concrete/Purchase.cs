using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

#nullable disable

namespace EntityLayer.Concrete

{
    public partial class Purchase: IEntity
    {
        [Key]
        public int PurchaseId { get; set; }
        public int TotalAmount { get; set; }
        public int? UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
