using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;

namespace PharmacyManagmentV2.Models
{
    public class RegisterViewModel
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

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string UserType { get; set; }

        
        public Pharmacy Pharmacy { get; set; }

        public Address Address { get; set; }


    }
}
