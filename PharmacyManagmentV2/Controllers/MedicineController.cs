using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace PharmacyManagmentV2.Controllers
{
    public class MedicineController : Controller
    {   
        private readonly IMedicineService _medicineService;
        private readonly ICategoryService _categorService;
        private readonly ILeafService _leafService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPurchaseService _purchaseService;
        private readonly IInvoiceService _invoiceService;
        private readonly ITypeService _typeService;
        private readonly IUnitService _unitService;
        public MedicineController(
             IMedicineService medicineService,
             ICategoryService categoryService,
             ILeafService leafService,
             IManufacturerService manufacturerService,
             IPurchaseService purchaseService,
             IInvoiceService invoiceService,
             ITypeService  TypeService,
             IUnitService unitService
            )
        {
            _medicineService = medicineService;
            _categorService = categoryService;
            _leafService = leafService;
            _manufacturerService = manufacturerService;
            _purchaseService = purchaseService;
            _invoiceService = invoiceService;
            _medicineService = medicineService;
            _unitService = unitService;
        }

        // GET: Medicine
        public IActionResult Index()
        {
            var appDBContext = _medicineService
                .GetMedicinesWithProperties();
            return View(appDBContext);
        }

        // GET: Medicine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _medicineService
                .GetMedicineWithProperties(id.Value);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicine/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categorService.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafService.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseService.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_invoiceService.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_typeService.GetTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitService.GetUnites(), "Id", "Name");
            return View();
        }

        // POST: Medicine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,GenericName,CategoryId,ManufacturerId,Shelf,Price,ManufacturerPrice,Strengh,TypeId,UnitId,Status,Details,Expriy,LeafId,SellId,PurchaseId,Id,CreatAt")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                using var _context = new AppDBContext();
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
       
            return View(medicine);
        }

        // GET: Medicine/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _medicineService.GetMedicine(id.Value);
            if (medicine == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categorService.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafService.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseService.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_invoiceService.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_typeService.GetTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitService.GetUnites(), "Id", "Name");
            return View(medicine);
        }

        // POST: Medicine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,GenericName,CategoryId,ManufacturerId,Shelf,Price,ManufacturerPrice,Strengh,TypeId,UnitId,Status,Details,Expriy,LeafId,SellId,PurchaseId,Id,CreatAt")] Medicine medicine)
        {
            if (id != medicine.ManufacturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using var _context = new AppDBContext();
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.ManufacturerId))
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
          
            return View(medicine);
        }

        // GET: Medicine/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _medicineService.GetMedicinesWithProperties();
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicine = _medicineService.GetMedicine(id);
            _medicineService.DeleteMedicine(medicine);
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            return _medicineService.GetMedicine(id) != null ? true : false;
        }
    }
}
