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

        public IActionResult Index()
        {
            return View(_leafManager.GetLeaves());
        }

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

        public IActionResult Create()
        {
            return View();
        }

       
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

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LeafType,TotalNumberPerBox,Id,CreatAt")] Leaf leaf)
        {
            if (id != leaf.LeafId)
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
                    if (!LeafExists(leaf.LeafId))
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
            return _leafManager.GetLeaf(id) != null ? true : false;
        }
    }
}
