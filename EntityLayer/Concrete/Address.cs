using System.ComponentModel.DataAnnotations;
using Core.Entities;


namespace EntityLayer.Concrete
{
    public partial class Address :IEntity
    {
        [Key]
        public int AddressId { get; set; }
        public string City{ get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public  bool AddressStatus { get; set; }

    }
}
