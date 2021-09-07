using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;

namespace PharmacyManagmentV2.Controllers
{
    public class MedicineController : Controller
    {
        private readonly AppDBContext _context;

        public MedicineController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Medicine
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Medicines
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Sell)
                .Include(m => m.Type)
                .Include(m => m.Unit);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Medicine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Sell)
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["LeafId"] = new SelectList(_context.Leaves, "Id", "LeafType");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Name");
            ViewData["SellId"] = new SelectList(_context.Sells, "Id", "Id");
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
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
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", medicine.CategoryId);
            ViewData["LeafId"] = new SelectList(_context.Leaves, "Id", "LeafType", medicine.LeafId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", medicine.ManufacturerId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Name", medicine.PurchaseId);
            ViewData["SellId"] = new SelectList(_context.Sells, "Id", "Id", medicine.SellId);
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Name", medicine.TypeId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", medicine.UnitId);
            return View(medicine);
        }

        // GET: Medicine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", medicine.CategoryId);
            ViewData["LeafId"] = new SelectList(_context.Leaves, "Id", "Id", medicine.LeafId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Id", medicine.ManufacturerId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id", medicine.PurchaseId);
            ViewData["SellId"] = new SelectList(_context.Sells, "Id", "Id", medicine.SellId);
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Id", medicine.TypeId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", medicine.UnitId);
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", medicine.CategoryId);
            ViewData["LeafId"] = new SelectList(_context.Leaves, "Id", "Id", medicine.LeafId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Id", medicine.ManufacturerId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id", medicine.PurchaseId);
            ViewData["SellId"] = new SelectList(_context.Sells, "Id", "Id", medicine.SellId);
            ViewData["TypeId"] = new SelectList(_context.MedicineTypes, "Id", "Id", medicine.TypeId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", medicine.UnitId);
            return View(medicine);
        }

        // GET: Medicine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .Include(m => m.Category)
                .Include(m => m.Leaf)
                .Include(m => m.Manufacturer)
                .Include(m => m.Purchase)
                .Include(m => m.Sell)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
            return _context.Medicines.Any(e => e.Id == id);
        }
    }
}
