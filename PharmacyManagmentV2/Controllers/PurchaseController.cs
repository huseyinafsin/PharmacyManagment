using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IGenericRepository<Pharmacy> _pharmacies;


        public PurchaseController(AppDBContext context,
                                   IManufacturerRepository manufacturerRepository,
                                   UserManager<ApplicationUser> userManager,
                                   IGenericRepository<Pharmacy> pharmacies
                                   )

        {
            _context = context;
            _manufacturerRepository = manufacturerRepository;
            _userManager = userManager;
            _pharmacies = pharmacies;

        }

        public AppDBContext Context => _context;

        public AppDBContext Context1 => _context;

        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            ViewData["CustomerList"] = _manufacturerRepository.GetManufacturers();
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