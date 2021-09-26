using System;
using System.Collections.Generic;


namespace EntityLayer.Concrete
{
    public partial class MedicineType { 

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool TypeStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
