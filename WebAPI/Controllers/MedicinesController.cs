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
    public class MedicinesController : Controller
    {
        private readonly IMedicineService _medicineService;

        [HttpPost("add")]
        public IActionResult Add(Medicine medicine)
        {
            var result = _medicineService.AddMedicine(medicine);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Medicine medicine)
        {
            var result = _medicineService.DeleteMedicine(medicine);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Medicine  medicine)
        {
            var result = _medicineService.UpdateMedicine(medicine);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int medicineId)
        {
            var result = _medicineService.GetMedicine(medicineId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(int medicineId)
        {
            var result = _medicineService.GetSingleMedicineWithDetails(medicineId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Medicine, bool>> expression = null)
        {
            var result = _medicineService.GetMedicines(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails(Expression<Func<Medicine, bool>> expression = null)
        {
            var result = _medicineService.GetMedicinesWithDetails(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
