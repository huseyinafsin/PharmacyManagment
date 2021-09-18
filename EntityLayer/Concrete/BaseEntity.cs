using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EntityLayer.Abstract
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatAt { get; set; } = DateTime.Now;
        public bool Status { get; set; } 
    }
}
