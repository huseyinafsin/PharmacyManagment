using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace WebAPI.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;   
        }

        [HttpPost("add")]
        public IActionResult Add(Address address)
        {
            var result = _addressService.AddAddress(address);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Address address)
        {
            var result = _addressService.DeleteAddress(address);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Address address)
        {
            var result = _addressService.UpdateAddress(address);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int addressId)
        {
            var result = _addressService.GetAddress(addressId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Address, bool>> expression = null)
        {
            var result = _addressService.GetAddresses(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
