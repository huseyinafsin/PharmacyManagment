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
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;

        public CustomerController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetCustomersWithDetails();
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
                _addressService.AddAddress(customer.Address);
                _customerService.AddCustomer(customer);
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult CustomerDetails(int customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            customer.CustomerStatus = false;
            _customerService.UpdateCustomer(customer);
            return RedirectToAction("Index","Home");
        }

    }
}
