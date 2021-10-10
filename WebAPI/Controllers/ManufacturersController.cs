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
    public class ManufacturersController : Controller
    {

        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService; 
        }

        [HttpPost("add")]
        public IActionResult Add(Manufacturer manufacturer)
        {
            var result = _manufacturerService.AddManufacturer(manufacturer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Manufacturer manufacturer)
        {
            var result = _manufacturerService.DeleteManufacturer(manufacturer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Manufacturer manufacturer)
        {
            var result = _manufacturerService.UpdateManufacturer(manufacturer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int manufacturerId)
        {
            var result = _manufacturerService.GetManufacturer(manufacturerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int manufacturerId)
        {
            var result = _manufacturerService.GetSingleManufacturerWithDetails(manufacturerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Manufacturer, bool>> expression = null)
        {
            var result = _manufacturerService.GetManufacturers(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Manufacturer, bool>> expression = null)
        {
            var result = _manufacturerService.GetManufacturersWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
