using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

#nullable disable

namespace EntityLayer.Concrete
{
    public partial class Medicine : IEntity
    {
        [Key]
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public int Shelf { get; set; }
        public int Price { get; set; }
        public int ManufacturerPrice { get; set; }
        public int Strengh { get; set; }
        public string Details { get; set; }
        public DateTime Expriy { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int LeafId { get; set; }
        public virtual Leaf Leaf { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int TypeId { get; set; }
        public virtual MedicineType Type { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public string MedicineImage { get; set; }
        public bool MedicineStatus { get; set; }


    }
}
