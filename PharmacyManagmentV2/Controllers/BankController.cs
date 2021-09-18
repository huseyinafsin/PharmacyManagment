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
    public class BankController : Controller
    {
        private readonly BankAccountManager _bankAccountManager;
        public BankController(BankAccountManager bankAccountManager)
        {
            _bankAccountManager = bankAccountManager;
        }

        // GET: BankAccounts
        public IActionResult Index()
        {
            return View(_bankAccountManager.GetBankAccounts().ToList());
        }

        // GET: BankAccounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = _bankAccountManager.GetBankAccounts().FirstOrDefault(b => b.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountNumber,AccountName,Branch,Balance,CreditLine,Id,CreatAt")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                _bankAccountManager.AddBankAccount(bankAccount);
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = _bankAccountManager.GetBankAccount(id.Value);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AccountNumber,AccountName,Branch,Balance,CreditLine,Id,CreatAt")] BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bankAccountManager.UpdateBankAccount(bankAccount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountExists(bankAccount.Id))
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
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = _bankAccountManager.GetBankAccount(id.Value);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var bankAccount = _bankAccountManager.GetBankAccount(id.Value);
            _bankAccountManager.DeleteBankAccount(bankAccount);

            return RedirectToAction(nameof(Index));
        }

        private bool BankAccountExists(int id)
        {
            return _bankAccountManager.GetBankAccounts().Any(e => e.Id == id);
        }
    }
}
