using System;
using System.Collections.Generic;

namespace  EntityLayer.Concrete

{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
