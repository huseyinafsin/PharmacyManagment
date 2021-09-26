using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PharmacyManagmentV2.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        public BankController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        // GET: BankAccounts
        public IActionResult Index()
        {
            return View(_bankAccountService.GetBankAccounts(b => b.AccountStatus == true));
        }

        // GET: BankAccounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = _bankAccountService.GetBankAccounts();
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
                bankAccount.AccountStatus = true;
                _bankAccountService.AddBankAccount(bankAccount);
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

            var bankAccount = _bankAccountService.GetBankAccount(id.Value);
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
            if (id != bankAccount.AccoıuntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bankAccountService.UpdateBankAccount(bankAccount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountExists(bankAccount.AccoıuntId))
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

            var bankAccount = _bankAccountService.GetBankAccount(id.Value);

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
            var bankAccount = _bankAccountService.GetBankAccount(id.Value);
            //  _bankAccountManager.DeleteBankAccount(bankAccount);
            bankAccount.AccountStatus = false;
            _bankAccountService.UpdateBankAccount(bankAccount);
            return RedirectToAction(nameof(Index));
        }

        private bool BankAccountExists(int id)
        {
            return _bankAccountService.GetBankAccount(id) != null ? true : false;
        }
    }
}
