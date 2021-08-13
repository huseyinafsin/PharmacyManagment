using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Interfaces
{
    public interface IEntity 
    {
        public int Id { get; set; }
        public DateTime? CreatAt { get; set; }
    }
}
