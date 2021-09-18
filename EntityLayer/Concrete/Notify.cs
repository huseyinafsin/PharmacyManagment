using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notify: BaseEntity
    {
        public string Message { get; set; }

    }
}
