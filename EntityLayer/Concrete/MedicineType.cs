using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace EntityLayer.Concrete
{
    public partial class MedicineType : IEntity
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool TypeStatus { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
