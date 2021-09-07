using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Models
{
    public class MedicineCreateModel
    {
        public string Name { get; set; }
        public string GenericName { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public int Shelf { get; set; }
        public int Price { get; set; }
        public int ManufacturerPrice { get; set; }
        public int Strengh { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public DateTime Expriy { get; set; }
        public string Leaf { get; set; }
       
    }
}
