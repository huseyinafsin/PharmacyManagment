using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PharmacyManagmentV2.Data
{
    public class ApplicationRole: IdentityRole<int>
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
