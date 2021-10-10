using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace WebAPI.Controllers
{
    public class TypesController : Controller
    {

        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService; 
        }

        [HttpPost("add")]
        public IActionResult Add(MedicineType type)
        {
            var result = _typeService.AddType(type);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(MedicineType type)
        {
            var result = _typeService.DeleteType(type);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(MedicineType type)
        {
            var result = _typeService.UpdateType(type);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int typeId)
        {
            var result = _typeService.GetType(typeId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<MedicineType, bool>> expression = null)
        {
            var result = _typeService.GetTypes(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
