using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Leaf:BaseEntity
    {
        public Leaf()
        {
            Medicines = new HashSet<Medicine>();
        }

       
        public string LeafType { get; set; }
        public int TotalNumberPerBox { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
