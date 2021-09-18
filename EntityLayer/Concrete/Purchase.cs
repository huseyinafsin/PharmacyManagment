using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete

{
    public partial class Purchase : BaseEntity
    {

        public Purchase()
        {
            Medicines = new HashSet<Medicine>();
        }
        public int TotalAmount { get; set; }
        public string AppUserId { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
