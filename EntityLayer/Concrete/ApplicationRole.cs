using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

 namespace EntityLayer.Concrete

{
    public class ApplicationRole: IdentityRole<int>, IEntity
    {
        public ApplicationRole()
        {
            this.Name = Name;
        }
        public ApplicationRole(string Name)
        {
            this.Name = Name;
        }

    }
}
