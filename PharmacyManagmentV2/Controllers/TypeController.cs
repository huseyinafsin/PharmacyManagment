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
    public class TypeController : Controller
    {
        ITypeService _typeService;
        
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: MedicineType
        public IActionResult Index()
        {
            return View(_typeService.GetTypes());
        }

        // GET: MedicineType/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _typeService.GetType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Status,Id,CreatAt")] MedicineType medicineType)
        {
            if (ModelState.IsValid)
            {
                _typeService.AddType(medicineType);
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _typeService.GetType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }
            return View(medicineType);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Status,Id,CreatAt")] MedicineType medicineType)
        {
            if (id != medicineType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _typeService.AddType(medicineType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineTypeExists(medicineType.TypeId))
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = _typeService.GetType(id.Value);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicineType = _typeService.GetType(id);
            if (medicineType!=null)
            {
                _typeService.DeleteType(medicineType);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineTypeExists(int id)
        {
            return _typeService.GetType(id) != null ? true : false;
        }
    }
}
