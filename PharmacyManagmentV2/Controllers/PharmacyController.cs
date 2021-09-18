using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;

namespace PharmacyManagmentV2.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IPharmacyRepository _pharmacyRepositry;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PharmacyController(AppDBContext context,
            UserManager<ApplicationUser> userManager,
            IPharmacyRepository pharmacyRepositry,
            IBankAccountRepository bankAccountRepository)

        {
            _context = context;
            _userManager = userManager;
            _pharmacyRepositry = pharmacyRepositry;
            _bankAccountRepository = bankAccountRepository;
        }

        // GET: Pharmacy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pharmacies.Include(p => p.BankAccount).ToListAsync());
        }

        // GET: Pharmacy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .Include(p => p.BankAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Name,Id,CreatAt")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacy);
        }

        // GET: Pharmacy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatAt")] Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacy);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // POST: Pharmacy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pharmacy/Users/id
        // [Authorize(Roles ="User Assign")]
        public IActionResult UserAssign(int id)
        {
            var allUsers = _userManager.Users.ToList();
            var pharmacyUsers = _pharmacyRepositry.GetUsers(id).Select(I => I.Id);
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

                    _pharmacyRepositry.AssignUser(id, item.UserId);
                }
                else
                {
                    _pharmacyRepositry.RemoveUser(id, item.UserId);

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

        public IActionResult SetBankAccount()
        {
            ViewData["BankAccounts"] = new SelectList(_context.BankAccounts.Where(p => p.IsTaken == false), "Id", "AccountName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetBankAccount(int id, BankAccount model)
        {
            var pharmacy = await _context.Pharmacies.Include(p => p.BankAccount).FirstOrDefaultAsync(m => m.Id == id);

            var bankAccount = _context.BankAccounts.FirstOrDefault(p => p.Id == model.Id);
            bankAccount.IsTaken = true;
            var lastAccount = pharmacy.BankAccount;
            lastAccount.IsTaken = false;
            pharmacy.BankAccount = bankAccount;
            _context.Pharmacies.Update(pharmacy);
            _context.UpdateRange(bankAccount,lastAccount);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        private bool PharmacyExists(int id)
        {
            return _context.Pharmacies.Any(e => e.Id == id);
        }
    }
}
