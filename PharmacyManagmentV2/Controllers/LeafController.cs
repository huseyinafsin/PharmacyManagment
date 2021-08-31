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
    public class LeafController : Controller
    {
        private readonly AppDBContext _context;

        public LeafController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Leaf
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leaves.ToListAsync());
        }

        // GET: Leaf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // GET: Leaf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leaf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeafType,TotalNumberPerBox,Id,CreatAt")] Leaf leaf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaf);
        }

        // GET: Leaf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves.FindAsync(id);
            if (leaf == null)
            {
                return NotFound();
            }
            return View(leaf);
        }

        // POST: Leaf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeafType,TotalNumberPerBox,Id,CreatAt")] Leaf leaf)
        {
            if (id != leaf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeafExists(leaf.Id))
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
            return View(leaf);
        }

        // GET: Leaf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // POST: Leaf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaf = await _context.Leaves.FindAsync(id);
            _context.Leaves.Remove(leaf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeafExists(int id)
        {
            return _context.Leaves.Any(e => e.Id == id);
        }
    }
}
