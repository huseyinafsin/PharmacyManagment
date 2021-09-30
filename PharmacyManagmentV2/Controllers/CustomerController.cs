using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
