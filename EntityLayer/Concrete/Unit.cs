using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Unit 
    {
        [Key]
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public bool UnitStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
