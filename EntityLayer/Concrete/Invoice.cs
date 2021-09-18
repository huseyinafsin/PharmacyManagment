﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Invoice : BaseEntity
    {
        public Invoice()
        {
            Medicines = new  HashSet<Medicine>();
        }
  
        public int AppUserId { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId{ get; set; }
        public virtual ApplicationUser AppUser { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
