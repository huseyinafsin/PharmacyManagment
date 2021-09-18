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
    public class MedicineTypeController : Controller
    {
        private readonly MedicineTypeManager _medicineTypeManager;
        public MedicineTypeController()
        {
        }

        // GET: MedicineType
        public IActionResult Index()
        {
            return View(_medicineTypeManager.GetMedicineTypes());
        }

        // GET: MedicineType/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _medicineTypeManager.GetMedicineType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // GET: MedicineType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Status,Id,CreatAt")] MedicineType medicineType)
        {
            if (ModelState.IsValid)
            {
                _medicineTypeManager.AddMedicineType(medicineType);
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        // GET: MedicineType/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _medicineTypeManager.GetMedicineType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }
            return View(medicineType);
        }

        // POST: MedicineType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Status,Id,CreatAt")] MedicineType medicineType)
        {
            if (id != medicineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _medicineTypeManager.AddMedicineType(medicineType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineTypeExists(medicineType.Id))
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
            return View(medicineType);
        }

        // GET: MedicineType/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _medicineTypeManager.GetMedicineType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // POST: MedicineType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicineType = _medicineTypeManager.GetMedicineType(id);
            if (medicineType!=null)
            {
                _medicineTypeManager.DeleteMedicineType(medicineType);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineTypeExists(int id)
        {
            return _medicineTypeManager.GetMedicineTypes().Any(e => e.Id == id);
        }
    }
}
