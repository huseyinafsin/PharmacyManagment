using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Models
{
    public class UserViewModel
    {
        [Required]
        public string Firtname { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }


        public Pharmacy Pharmacy { get; set; }

        public Address Address { get; set; }


    }
}
