using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Entities
{
    public partial class Sell : BaseEntity
    {
        public Sell()
        {
            Medicines = new  HashSet<Medicine>();
        }
  
        public int AppUserId { get; set; }
        public DateTime SellDate { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId{ get; set; }
        public virtual ApplicationUser AppUser { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
