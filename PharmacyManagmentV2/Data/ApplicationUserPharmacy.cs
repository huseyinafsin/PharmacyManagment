using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Data
{
    public class ApplicationUserPharmacy :BaseEntity
    {

     
        public int ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public  int PharmacyId { get; set; }
        [ForeignKey("PharmacyId")]
        public Pharmacy Pharmacy { get; set; }


    }
}
