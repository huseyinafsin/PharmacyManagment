using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace WebAPI.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;   
        }

        [HttpPost("add")]
        public IActionResult Add(BankAccount bankAccount)
        {
            var result = _bankAccountService.AddBankAccount(bankAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(BankAccount bankAccount)
        {
            var result = _bankAccountService.DeleteBankAccount(bankAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(BankAccount bankAccount)
        {
            var result = _bankAccountService.UpdateBankAccount(bankAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int bankAccountId)
        {
            var result = _bankAccountService.GetBankAccount(bankAccountId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<BankAccount, bool>> expression = null)
        {
            var result = _bankAccountService.GetBankAccounts(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
