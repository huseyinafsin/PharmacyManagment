using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public partial class MedicineType {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool TypeStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
