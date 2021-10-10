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
    public class LeavesController : Controller
    {
        private readonly ILeafService _leafService;

        public LeavesController(ILeafService leafService)
        {
            _leafService = leafService; 
        }

        [HttpPost("add")]
        public IActionResult Add(Leaf leaf)
        {
            var result = _leafService.AddLeaf(leaf);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Leaf leaf)
        {
            var result = _leafService.DeleteLeaf(leaf);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Leaf leaf)
        {
            var result = _leafService.UpdateLeaf(leaf);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int leafId)
        {
            var result = _leafService.GetLeaf(leafId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Leaf, bool>> expression = null)
        {
            var result = _leafService.GetLeaves(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
