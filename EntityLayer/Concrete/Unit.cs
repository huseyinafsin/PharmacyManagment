using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Abstract;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Unit : BaseEntity
    {
        public Unit()
        {
            Medicines = new HashSet<Medicine>();
        }

      
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
