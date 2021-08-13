using PharmacyManagmentV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Models
{
    public class CustomerAdressModel
    {
        public Customer customer { get; set; }
        public Address address { get; set; }

    }
}
