using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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

        // GET: Pharmacy
        public IActionResult Index()
        {
            var pharmacies = _pharmacyService
                .GetPharmacies().Result
                .Include(p => p.BankAccount)
                .ToList();
            return View(pharmacies);
        }

        // GET: Pharmacy/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = _pharmacyService.GetPharmacies().Result
                .Include(p => p.BankAccount)
                .FirstOrDefault(p => p.Id == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // GET: Pharmacy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Pharmacy/Edit/5
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

        // POST: Pharmacy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id,CreatAt")] Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
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
                    if (!PharmacyExists(pharmacy.Id))
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

        // GET: Pharmacy/Delete/5
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

        // POST: Pharmacy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pharmacy = _pharmacyService.GetPharmacy(id);
            _pharmacyService.DeletePharmacy(pharmacy);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pharmacy/Users/id
        // [Authorize(Roles ="User Assign")]
        public IActionResult UserAssign(int id)
        {
            var allUsers = _userManager.Users.ToList();
            var pharmacyUsers = _pharmacyService.GetUsers(id).Select(I => I.Id);
            var assignUsers = new List<SetUserViewModel>();

            allUsers.ForEach(user => assignUsers.Add(new SetUserViewModel
            {
                HasAssign = pharmacyUsers.Contains(user.Id),
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
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

            var bankAccount = _bankAccountService.GetBankAccount( model.Id);
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
            return _pharmacyService.GetPharmacies().Result.Any(e => e.Id == id);
        }
    }
}
