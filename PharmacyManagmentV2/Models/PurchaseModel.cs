using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace PharmacyManagmentV2.Models
{
    public class PurchaseModel
    {
        public Pharmacy Pharmacy { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatAt { get; set; }
        public int TotalAmount { get; set; }
        public BankAccount BankAccount { get; set; }
        public List<ProductModel> Products { get; set; }
     }
}
