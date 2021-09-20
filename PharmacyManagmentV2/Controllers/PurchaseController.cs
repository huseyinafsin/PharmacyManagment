using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ManufacturerManager _manufacturerManager;
        private readonly PharmcyManager _pharmcyManager;


        public PurchaseController(
                                   PharmcyManager pharmcyManager,
                                   UserManager<ApplicationUser> userManager,
                                   ManufacturerManager manufacturerManager
                                   )

        {
            _manufacturerManager = manufacturerManager;
            _userManager = userManager;
            _pharmcyManager = pharmcyManager;

        }



        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            ViewData["CustomerList"] = _manufacturerManager.GetManufacturers();
            var currentUserId = int.Parse(_userManager.GetUserId(User));
            var currentUser = _userManager.Users.Include(m => m.Pharmacy).Include(m => m.Pharmacy.BankAccount).FirstOrDefault(p => p.Id == currentUserId);
            var userPharmacy = currentUser.Pharmacy;
            var pharmcyBankAccount = currentUser.Pharmacy.BankAccount;
          
            var model = new PurchaseModel();
            model.ApplicationUser = currentUser;
            model.Pharmacy = userPharmacy;
            model.Pharmacy.BankAccount = pharmcyBankAccount;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseModel model)
        {

            return RedirectToAction("Index");
        }

    }
}