using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly MedicineManager _medicineManager;
        private readonly CategoryManager _categoryManager;
        private readonly LeafManager _leafManager;
        private readonly ManufacturerManager _manufacturerManager;
        private readonly PurchaseManager _purchaseManager;
        private readonly InvoiceManager _ınvoiceManager;
        private readonly MedicineTypeManager _medicineTypeManager;
        private readonly UnitManager _unitManager;
        public MedicineController(
             MedicineManager medicineManager,
             CategoryManager categoryManager,
             LeafManager leafManager,
             ManufacturerManager manufacturerManager,
             PurchaseManager purchaseManager,
             InvoiceManager ınvoiceManager,
             MedicineTypeManager medicineTypeManager,
             UnitManager unitManager
            )
        {
            _medicineManager = medicineManager;
            _categoryManager = categoryManager;
            _leafManager = leafManager;
            _manufacturerManager = manufacturerManager;
            _purchaseManager = purchaseManager;
            _ınvoiceManager = ınvoiceManager;
            _medicineManager = medicineManager;
            _unitManager = unitManager;
        }

        // GET: Medicine
        public IActionResult Index()
        {
            var appDBContext = _medicineManager
                .GetMedicines()
                .AsQueryable()
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Invoice)
                .Include(m => m.Type)
                .Include(m => m.Unit)
                .ToList();
            return View(appDBContext);
        }

        // GET: Medicine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _medicineManager
                .GetMedicines()
                .AsQueryable()
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Invoice)
                .Include(m => m.Type)
                .Include(m => m.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicine/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryManager.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafManager.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerManager.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseManager.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_ınvoiceManager.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_medicineTypeManager.GetMedicineTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitManager.GetUnites(), "Id", "Name");
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
            ViewData["CategoryId"] = new SelectList(_categoryManager.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafManager.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerManager.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseManager.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_ınvoiceManager.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_medicineTypeManager.GetMedicineTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitManager.GetUnites(), "Id", "Name");
            return View(medicine);
        }

        // GET: Medicine/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _medicineManager.GetMedicine(id.Value);
            if (medicine == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryManager.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafManager.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerManager.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseManager.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_ınvoiceManager.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_medicineTypeManager.GetMedicineTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitManager.GetUnites(), "Id", "Name");
            return View(medicine);
        }

        // POST: Medicine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,GenericName,CategoryId,ManufacturerId,Shelf,Price,ManufacturerPrice,Strengh,TypeId,UnitId,Status,Details,Expriy,LeafId,SellId,PurchaseId,Id,CreatAt")] Medicine medicine)
        {
            if (id != medicine.Id)
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
                    if (!MedicineExists(medicine.Id))
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
            ViewData["CategoryId"] = new SelectList(_categoryManager.GetCategories(), "Id", "Name");
            ViewData["LeafId"] = new SelectList(_leafManager.GetLeaves(), "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_manufacturerManager.GetManufacturers(), "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_purchaseManager.GetPurchases(), "Id", "Name");
            ViewData["SellId"] = new SelectList(_ınvoiceManager.GetInvoices(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_medicineTypeManager.GetMedicineTypes(), "Id", "Name");
            ViewData["UnitId"] = new SelectList(_unitManager.GetUnites(), "Id", "Name");
            return View(medicine);
        }

        // GET: Medicine/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _medicineManager.GetMedicines()
                .AsQueryable()
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Invoice)
                .Include(m => m.Type)
                .Include(m => m.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var medicine = _medicineManager.GetMedicine(id);
            _medicineManager.DeleteMedicine(medicine);
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            return _medicineManager.GetMedicines().Any(e => e.Id == id);
        }
    }
}
