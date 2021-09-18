using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PharmacyManagmentV2.Controllers
{
    public class LeafController : Controller
    {
        private readonly LeafManager _leafManager;
        public LeafController(LeafManager leafManager)
        {
            _leafManager = leafManager;
        }

        // GET: Leaf
        public IActionResult Index()
        {
            return View(_leafManager.GetLeaves());
        }

        // GET: Leaf/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = _leafManager.GetLeaf(id.Value);
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
        public IActionResult Create([Bind("LeafType,TotalNumberPerBox,Id,CreatAt")] Leaf leaf)
        {
            if (ModelState.IsValid)
            {
                _leafManager.AddLeaf(leaf);
                return RedirectToAction(nameof(Index));
            }
            return View(leaf);
        }

        // GET: Leaf/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = _leafManager.GetLeaf(id.Value);
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
        public IActionResult Edit(int id, [Bind("LeafType,TotalNumberPerBox,Id,CreatAt")] Leaf leaf)
        {
            if (id != leaf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _leafManager.UpdateLeaf(leaf);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaf = _leafManager.GetLeaf(id.Value);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // POST: Leaf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var leaf = _leafManager.GetLeaf(id);
            if (leaf != null)
            {
                _leafManager.DeleteLeaf(leaf);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LeafExists(int id)
        {
            return _leafManager.GetLeaves().Any(e => e.Id == id);
        }
    }
}
