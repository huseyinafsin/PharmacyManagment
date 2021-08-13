using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Entities;

namespace PharmacyManagmentV2.Models
{
    public class CustomerViewModel
    {
       
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name can't be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can't be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insert numeric value")]
        public int Balance { get; set; }

        [Required(ErrorMessage = "Choese your gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter your BirdDay")]
        public DateTime DateOfBird { get; set; }


        [Required(ErrorMessage = "Enter your phone number")] 
        public int Phone { get; set; }

        [Required(ErrorMessage = "Choese your city")]
        public string City { get; set; } 
        
        [Required(ErrorMessage = "Choese your state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter zip code")]
        public int Zip { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }




    }
}
