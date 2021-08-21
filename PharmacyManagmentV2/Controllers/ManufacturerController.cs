using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IGenericRepository<Manufacturer> _manufacturer;
        private readonly IGenericRepository<Address> _address;

        public ManufacturerController(AppDBContext context,
            IGenericRepository<Manufacturer> manufacturer,
            IGenericRepository<Address> address)
        {
            _context = context;
            _manufacturer = manufacturer;
            _address = address;
        }

        // GET: Application/Manufacturer
        [Authorize(Roles ="List Manufacturer")]
        public async Task<IActionResult> Index()
        {
            var manufacturers = _manufacturer
                .GetAll()
                .Include(m => m.Address);
            return View(await manufacturers.ToListAsync());
        }

        // GET: Application/Manufacturer/Details/5
        [Authorize(Roles = "Manufacturer Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturer
                .GetAll()
                .Include(m => m.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Application/Manufacturer/Create
        [HttpGet]
        [Authorize(Roles = "Create Manufacturer")]
        public IActionResult Create()
        {

            return View();
        }

        // POST: Application/Manufacturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                await _manufacturer.Create(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Application/Manufacturer/Edit/5
        [HttpGet]
        [Authorize(Roles = "Edit Manufacturer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturer
                .GetAll()
                .Include(c=>c.Address)
                .FirstOrDefaultAsync(c=>c.Id==id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Application/Manufacturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _manufacturer.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
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
            return View(manufacturer);
        }

        // GET: Application/Manufacturer/Delete/5
        [HttpGet]
        [Authorize(Roles ="Delete Manufacturer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturer
                .GetAll()
                .Include(m => m.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Application/Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _manufacturer
                .GetAll()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);

            await _address.Delete(manufacturer.Address);
            await _manufacturer.Delete(manufacturer);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturer.GetAll().Any(e => e.Id == id);
        }
    }
}
