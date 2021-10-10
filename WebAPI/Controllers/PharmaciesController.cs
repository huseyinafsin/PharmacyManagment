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
    public class PharmaciesController : Controller
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmaciesController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpPost("add")]
        public IActionResult Add(Pharmacy pharmacy)
        {
            var result = _pharmacyService.AddPharmacy(pharmacy);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Pharmacy pharmacy)
        {
            var result = _pharmacyService.DeletePharmacy(pharmacy);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Pharmacy pharmacy)
        {
            var result = _pharmacyService.UpdatePharmacy(pharmacy);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int pharmacyId)
        {
            var result = _pharmacyService.GetPharmacy(pharmacyId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int pharmacyId)
        {
            var result = _pharmacyService.GetSinglePharmacyWithDetails(pharmacyId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Pharmacy, bool>> expression = null)
        {
            var result = _pharmacyService.GetPharmacies(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Pharmacy, bool>> expression = null)
        {
            var result = _pharmacyService.GetPharmaciesWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
