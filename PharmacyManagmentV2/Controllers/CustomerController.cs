using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerManager _customerManager;

        public CustomerController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: Application/Customer
        [HttpGet]
        [ActionName("Index")]
        [Authorize(Roles = "List Customers")]
        public IActionResult Index()
        {
            var customers = _customerManager.GetCustomers().AsQueryable()
                .Include(c => c.Address).ToList();
            return View(customers);

        }

        // GET: Application/Customer/Details/5
        [HttpGet]
        [ActionName("Details")]
        [Authorize(Roles ="Customer Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerManager
                .GetCustomers()
                .AsQueryable()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Application/Customer/Create
        [HttpGet]
        [ActionName("Create")]
        [Authorize(Roles ="Create Customer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Application/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerManager.AddCustomer(customer);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Application/Customer/Edit/5
        [HttpGet]
        [ActionName("Edit")]
        [Authorize(Roles = "Edit Customer")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customers.FindAsync(id);
            var customer = _customerManager
                .GetCustomers()
                .AsQueryable()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
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
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerManager.UpdateCustomer(customer);
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
        [ActionName("Delete")]
        [Authorize(Roles = "Delete Customer")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerManager
                .GetCustomers()
                .AsQueryable()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id).Result;
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Application/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var customer = _customerManager
                .GetCustomers()
                .AsQueryable()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id).Result;

            _customerManager.DeleteCustomer(customer);

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerManager.GetCustomers()
                .Any(e => e.Id == id);
        }
    }
}
