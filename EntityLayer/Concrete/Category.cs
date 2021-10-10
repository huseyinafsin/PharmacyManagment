using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace  EntityLayer.Concrete

{
    public partial class Category: IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
