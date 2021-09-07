using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PharmacyManagmentV2.Data;

#nullable disable

namespace PharmacyManagmentV2.Data
{
    public partial class Medicine : BaseEntity
    {
        public Medicine()
        {
            Pharmacies = new HashSet<Pharmacy>();

        }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int Shelf { get; set; }
        public int Price { get; set; }
        public int ManufacturerPrice { get; set; }
        public int Strengh { get; set; }
        public int TypeId { get; set; }
        public int UnitId { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public DateTime Expriy { get; set; }
        public int LeafId { get; set; }
        [ForeignKey("SellId")]
        public int? SellId { get; set; }
        public int? PurchaseId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Leaf Leaf { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual MedicineType Type { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Invoice Sell{ get; set; }
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }

    }
}
