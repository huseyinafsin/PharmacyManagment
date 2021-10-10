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
    public class PurchasesController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService; 
        }

        [HttpPost("add")]
        public IActionResult Add(Purchase purchase)
        {
            var result = _purchaseService.AddPurchase(purchase);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Purchase purchase)
        {
            var result = _purchaseService.DeletePurchase(purchase);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Purchase purchase)
        {
            var result = _purchaseService.UpdatePurchase(purchase);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int purchaseId)
        {
            var result = _purchaseService.GetPurchase(purchaseId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int purchaseId)
        {
            var result = _purchaseService.GetSinglePurchaseWithDetails(purchaseId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Purchase, bool>> expression = null)
        {
            var result = _purchaseService.GetPurchases(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Purchase, bool>> expression = null)
        {
            var result = _purchaseService.GetPurchasesWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
