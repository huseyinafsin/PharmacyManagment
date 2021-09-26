using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
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
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController( IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [Authorize(Roles = "List Manufacturer")]
        public IActionResult Index()
        {
            var manufacturers = _manufacturerService
                .GetManufacturers();
            return View(manufacturers);
        }

        [Authorize(Roles = "Manufacturer Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturerService
                .GetManufacturerWithPropeties(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        [HttpGet]
        [Authorize(Roles = "Create Manufacturer")]
        public IActionResult Create()
        {

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _manufacturerService.AddManufacturer(manufacturer);

                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        [HttpGet]
        [Authorize(Roles = "Edit Manufacturer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturerService.GetManufacturersWithProperties();
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.ManufacturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _manufacturerService.UpdateManufacturer(manufacturer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.ManufacturerId))
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

        [HttpGet]
        [Authorize(Roles ="Delete Manufacturer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturerService
                .GetManufacturerWithPropeties(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = _manufacturerService
                .GetManufacturerWithPropeties(id);

            _manufacturerService.DeleteManufacturer(manufacturer);

            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturerService.GetManufacturerWithPropeties(id) != null ? true : false;
        }
    }
}
