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
    public class InvoicesController : Controller
    {

        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;   
        }

        [HttpPost("add")]
        public IActionResult Add(Invoice invoice)
        {
            var result = _invoiceService.AddInvoice(invoice);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Invoice invoice)
        {
            var result = _invoiceService.DeleteInvoice(invoice);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Invoice invoice)
        {
            var result = _invoiceService.UpdateInvoice(invoice);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int invoiceId)
        {
            var result = _invoiceService.GetInvoice(invoiceId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int invoiceId)
        {
            var result = _invoiceService.GetSingleInvoiceWithDetails(invoiceId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Invoice, bool>> expression = null)
        {
            var result = _invoiceService.GetInvoices(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Invoice, bool>> expression = null)
        {
            var result = _invoiceService.GetInvoicesWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
