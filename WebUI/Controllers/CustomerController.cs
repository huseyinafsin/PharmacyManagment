using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult CustomerList()
        {
           
            var customers = _customerService.GetCustomersWithAddress();
            return View(customers);
        }
        [HttpGet]
        public IActionResult CreateCustomer() => View();
        [HttpPost]
        public IActionResult CreateCustomer( Customer customer)
        {
            if (ModelState.IsValid)
            {
                    customer.CustomerStatus = true;
                _customerService.AddCustomer(customer);
                return RedirectToAction(nameof(CustomerList));
            }
            else
            {
                return View(ViewBag.Error="Customer did't inserted");
            }
        }
    }
}
