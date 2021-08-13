using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Entities;
using PharmacyManagmentV2.Interfaces;

namespace PharmacyManagmentV2.Areas.Application.Controllers
{
    [Area("Application")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IGenericRepository<Customer> _customer;
        private readonly IGenericRepository<Address> _address;

        public CustomerController(AppDBContext context,
            IGenericRepository<Customer> customer,
            IGenericRepository<Address> address)
        {
            _context    =   context;
            _customer   =   customer;
            _address    =  address;
        }

        // GET: Application/Customer
        public async Task<IActionResult> Index()
        {
            var customers = _customer.GetAll().Include(c => c.Address);
            return View(await customers.ToListAsync());
        }

        // GET: Application/Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customer
                .GetAll()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Application/Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Application/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Customer customer)
        {
           // [Bind("FirstName,Email,Balance,LastName,Gender,DateofBird,Phone,AddressId,Id,CreatAt")]
            if (ModelState.IsValid)
            {
                await  _address.Create(customer.Address);
               await _customer.Create(customer);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Application/Customer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customers.FindAsync(id);
            var customer = await _customer
                .GetAll()
                .Include(c=>c.Address)
                .FirstOrDefaultAsync(c=>c.Id==id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Application/Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _address.Update(customer.Address);
                    await _customer.Update(customer);
                    await _customer.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Application/Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customer
                .GetAll()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Application/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var customer = await _customer
                .GetAll()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id==id);

            await _address.Delete(customer.Address);
           await _customer.Delete(customer);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customer.GetAll()
                .Any(e => e.Id == id);
        }
    }
}
