using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDBContext _context;
        public CustomerRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
             return  _context.Customers.Include(b => b.BankAccount).ToList();
        }
    }
}
