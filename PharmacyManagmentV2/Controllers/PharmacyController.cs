using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly IBankAccountService _bankAccountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PharmacyController(
            UserManager<ApplicationUser> userManager,
            IBankAccountService bankAccountService,
            IPharmacyService pharmacyService)
        {
            _userManager = userManager;
            _pharmacyService = pharmacyService;
            _bankAccountService = bankAccountService;
        }

        public IActionResult Index()
        {
            var pharmacies = _pharmacyService.GetPharmaciesWithBankAccount();
            return View(pharmacies);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = _pharmacyService.GetPharmaciesWithBankAccount();
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id,CreatAt")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                _pharmacyService.AddPharmacy(pharmacy);
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacy);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = _pharmacyService.GetPharmacy(id.Value);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return View(pharmacy);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id,CreatAt")] Pharmacy pharmacy)
        {
            if (id != pharmacy.PharmacyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pharmacyService.UpdatePharmacy(pharmacy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmacyExists(pharmacy.PharmacyId))
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
            return View(pharmacy);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = _pharmacyService.GetPharmacy(id.Value);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pharmacy = _pharmacyService.GetPharmacy(id);
            _pharmacyService.DeletePharmacy(pharmacy);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles ="User Assign")]
        public IActionResult UserAssign(int id)
        {
            var allUsers = _userManager.Users.ToList();
            var pharmacyUsers = _pharmacyService;
            var assignUsers = new List<SetUserViewModel>();

            allUsers.ForEach(user => assignUsers.Add(new SetUserViewModel
            {
                HasAssign = pharmacyUsers.Contains(user.Id),
                UserId = user.Id,
                
            }));
            return View(assignUsers);
        }

        [HttpPost]
        public IActionResult UserAssign(int id, List<SetUserViewModel> list)
        {

            foreach (var item in list)
            {
                if (item.HasAssign)
                {

                    _pharmacyService.AssignUser(id, item.UserId);
                }
                else
                {
                    _pharmacyService.RemoveUser(id, item.UserId);

                }
            }
            return RedirectToAction("Index");
        }

        //GET: Pharmacy/Users/id
        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }

        public async Task<IActionResult> SetBankAccount()
        {
            using var _context = new AppDBContext();
            ViewData["BankAccounts"] = new SelectList(_context.BankAccounts.ToList(), "Id", "AccountName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetBankAccountAsync(int id, BankAccount model)
        {
            var pharmacy = await _pharmacyService.GetPharmacies().Result
                .Include(p => p.BankAccount)
                .FirstOrDefaultAsync(m => m.Id == id);

            var bankAccount = _bankAccountService.GetBankAccount( model.AccoıuntId);
            bankAccount.IsTaken = true;
            var lastAccount = pharmacy.BankAccount;
            lastAccount.IsTaken = false;
            pharmacy.BankAccount = bankAccount;
            _pharmacyService.UpdatePharmacy(pharmacy);
            _bankAccountService.UpdateBankAccount(bankAccount);
            _bankAccountService.UpdateBankAccount(lastAccount);

            return RedirectToAction(nameof(Index));
        }
        private bool PharmacyExists(int id)
        {
            return _pharmacyService.GetPharmacy(id) != null ? true : false;

        }
    }
}
