using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Invoice: IEntity
    {
        [Key]
        public int InvoiceId { get; set; }
        public int TotalAmount { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
