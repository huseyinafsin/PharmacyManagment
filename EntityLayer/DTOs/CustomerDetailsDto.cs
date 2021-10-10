using System;
using Core.Entities;

namespace EntityLayer.DTOs
{
    public class CustomerDetailsDto :IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBird { get; set; }

    }
}
