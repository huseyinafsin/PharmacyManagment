using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;

namespace PharmacyManagmentV2.Models
{
    public class ProductModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int numberOfProduct { get; set; }
        public Medicine Medicine { get; set; }
    }
}
