using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacyManagmentV2.Entities;
using PharmacyManagmentV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Areas.Admin.Controllers
{
    [Area("Application")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ILogger logger;

        public HomeController(RoleManager<ApplicationRole> roleManager,
                                ILogger<HomeController> logger
                                )
        {
          this.roleManager = roleManager;
            this.logger = logger;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRole( CreateRoleViewModel model)
        {
            var roleExist = await roleManager.RoleExistsAsync(model.RoleName);

         
            if (!roleExist)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(model.RoleName));

                }

            return View(model);

        }


       
        
    }
}