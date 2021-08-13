using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;

namespace PharmacyManagmentV2.Data
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime? CreatAt { get; set; } = DateTime.Now;
    }
}
