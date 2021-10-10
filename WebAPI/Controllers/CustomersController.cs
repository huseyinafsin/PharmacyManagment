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
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }



        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }  
        
        
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.DeleteCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }    
        

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int customerId)
        {
            var result = _customerService.GetCustomer(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }   
        
        
        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int customerId)
        {
            var result = _customerService.GetSingleCustomerWithDetails(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Customer, bool>> expression = null)
        {
            var result = _customerService.GetCustomers(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Customer, bool>> expression = null)
        {
            var result = _customerService.GetCustomersWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
