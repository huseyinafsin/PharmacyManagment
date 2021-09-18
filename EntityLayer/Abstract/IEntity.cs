using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IEntity 
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatAt { get; set; }

    }
}
