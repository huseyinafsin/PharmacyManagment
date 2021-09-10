using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyManagmentV2.Data;

namespace PharmacyManagmentV2.Models
{
    public class PurchaseModel
    {
        public Pharmacy Pharmacy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatAt { get; set; }
        public int TotalAmount { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public BankAccount BankAccount { get; set; }
        public List<ProductModel> Products { get; set; }
     }
}
