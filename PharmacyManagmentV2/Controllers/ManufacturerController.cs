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
    public class ManufacturerController : Controller
    {
        private readonly ManufacturerManager _manufacturerManager;

        public ManufacturerController( ManufacturerManager manufacturerManager)
        {
            _manufacturerManager = manufacturerManager;
        }

        // GET: Application/Manufacturer
        [Authorize(Roles = "List Manufacturer")]
        public IActionResult Index()
        {
            var manufacturers = _manufacturerManager
                .GetManufacturers().Result
                .Include(m => m.Address).ToList();
            return View(manufacturers);
        }

        // GET: Application/Manufacturer/Details/5
        [Authorize(Roles = "Manufacturer Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturerManager
                .GetManufacturers().Result
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
        public IActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _manufacturerManager.AddManufacturer(manufacturer);

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

            var manufacturer = await _manufacturerManager
                .GetManufacturers().Result
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
        public IActionResult Edit(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _manufacturerManager.UpdateManufacturer(manufacturer);
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

            var manufacturer = await _manufacturerManager
                .GetManufacturers().Result
                .AsQueryable()
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
            var manufacturer = await _manufacturerManager
                .GetManufacturers().Result
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);

            _manufacturerManager.DeleteManufacturer(manufacturer);

            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturerManager.GetManufacturers().Result.Any(e => e.Id == id);
        }
    }
}
