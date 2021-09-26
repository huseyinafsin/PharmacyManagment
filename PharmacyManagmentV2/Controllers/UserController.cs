using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PharmacyManagmentV2.Models;
//23.08.2021- 15.00
namespace PharmacyManagmentV2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UserController> _logger;
        private readonly AddressManager _addressManager;

        public UserController(
                            UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            RoleManager<ApplicationRole> roleManager,
                            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        // GET: Application/User
        [ActionName("Index")]
        [Authorize(Roles = "List User")]
        public async Task<IActionResult> Index()
        {

            var appDBContext = _userManager.Users.Include(a => a.Address).Where(u=>u.UserStatus==true);
            return View(await appDBContext.ToListAsync());
        }



        [HttpGet]
        [AllowAnonymous]
        [ActionName("Login")]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var _user = await _userManager.FindByEmailAsync(user.Email);
            if (ModelState.IsValid && _user.UserStatus==true)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        [HttpGet]
       // [Authorize(Roles ="Register")]
        [ActionName("Register")]
        public IActionResult Register(string returnUrl = null)
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl=null)
        {
            returnUrl ??= Url.Content("~/");


            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {

                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserType = model.UserType,
                    Address = model.Address,
                    UserStatus = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                   
                    if (model.UserType == 1)
                    {
                       await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else if (model.UserType==2)
                    {
                       await _userManager.AddToRoleAsync(user, "Employee");
                    }
                    else{
                       await _userManager.AddToRoleAsync(user, "Advisor");
                    }
                  

                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(model);

        }

        [ActionName("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");

        }


        // GET: Application/User/Details/5
        [Authorize(Roles ="User Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser =_userManager.Users
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }


        // GET: Application/User/Edit/5
        [Authorize(Roles = "Edit User")]
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByIdAsync(id.Value.ToString()).Result;
            if (user == null)
            {
                return NotFound();
            }
            
            var model = new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = _addressManager.GetAddress((int)user.AddressId)
            };
            
            return View(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, UserViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByIdAsync(id.ToString()).Result;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Address = model.Address;
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
            
        [Authorize(Roles = "Profile")]
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = _addressManager.GetAddress((int)user.AddressId)
            };
            
            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(int id, UserViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id.ToString());
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Address = model.Address;
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles ="Delete User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _userManager.Users.ToList().AsQueryable()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
            applicationUser.UserStatus = false;
            await _userManager.UpdateAsync(applicationUser);
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _userManager.Users.Any(e => e.Id == id);
        }
    }
}
