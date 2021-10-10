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
    public class NotifiesController : Controller
    {

        private readonly INotifyService _notifyService;

        public NotifiesController(INotifyService notifyService)
        {
            _notifyService = notifyService; 
        }

        [HttpPost("add")]
        public IActionResult Add(Notify  notify)
        {
            var result = _notifyService.AddNotify(notify);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Notify notify)
        {
            var result = _notifyService.DeleteNotify(notify);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Notify notify)
        {
            var result = _notifyService.UpdateNotify(notify);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("get")]
        public IActionResult GetById(int notifyId)
        {
            var result = _notifyService.GetNotify(notifyId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getall")]
        public IActionResult GetAll(Expression<Func<Notify, bool>> expression = null)
        {
            var result = _notifyService.GetNotifies(expression);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
