using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PharmacyManagmentV2.Entities
{
    public class ApplicationRole: IdentityRole<int>
    {
        public ApplicationRole(string Name)
        {
            this.Name = Name;
        }
        public int Id { get; set; }
    }
}
