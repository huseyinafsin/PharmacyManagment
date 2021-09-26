using System;
using System.Collections.Generic;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Leaf
    {

        public int LeafId { get; set; }
        public string LeafName { get; set; }
        public int TotalNumberPerBox { get; set; }
        public bool LeafStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
