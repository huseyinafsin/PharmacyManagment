using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KRNCUB4\\SQLEXPRESS;Database=PharmacyManagment; Integrated Security=True;");
        }
     
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Leaf> Leaves { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineType> Types { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
    }
}
