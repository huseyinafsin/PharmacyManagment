using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Models
{
    public class CreateRoleViewModel
    {
        public int Id { get; set; }
        [Required()]
        public string RoleName { get; set; }
    }
}
