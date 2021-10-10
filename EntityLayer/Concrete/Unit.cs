using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Unit : IEntity
    {
        [Key]
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public bool UnitStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
