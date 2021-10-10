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
    public class UnitsController : Controller
    {

        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost("add")]
        public IActionResult Add(Unit unit)
        {
            var result = _unitService.AddUnit(unit);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Unit unit)
        {
            var result = _unitService.DeleteUnit(unit);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Unit unit)
        {
            var result = _unitService.UpdateUnit(unit);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int unitId)
        {
            var result = _unitService.GetUnit(unitId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Unit, bool>> expression = null)
        {
            var result = _unitService.GetUnites(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
