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
            _addressManager = new AddressManager();
        }

        // GET: Application/User
        [ActionName("Index")]
        [Authorize(Roles = "List User")]
        public async Task<IActionResult> Index()
        {

            var appDBContext = _userManager.Users.Include(a => a.Address).Where(u=>u.Status==true);
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
            if (ModelState.IsValid && _user.Status==true)
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
                    FirstName = model.Firtname,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserType = model.UserType,
                    Address = model.Address,
                    Status = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var  assignRoles = new List<ApplicationRole>();
                    var roleNames = new List<string>();
                   
                    if (model.UserType == "Administor")
                    {
                        assignRoles = _roleManager.Roles.ToList();
                    }
                    else if (model.UserType=="Employee")
                    {
                        roleNames.Add("List Customers");
                        roleNames.Add("Customer Details");
                        roleNames.Add("Home Page");
                        roleNames.Add("List Manufacturer");
                    }
                    else{
                        roleNames.Add("List Customers");
                        roleNames.Add("Customer Details");
                        roleNames.Add("Home Page");
                    }

                    foreach (var role in roleNames)
                        assignRoles.Add(new ApplicationRole { Name = role });

                    foreach (var role in assignRoles)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
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
                Firtname =user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = _addressManager.GetAddress((int)user.AddressId)
            };
            
            return View(model);
        }

        // POST: Application/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, UserViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByIdAsync(id.ToString()).Result;
                    user.FirstName  = model.Firtname;
                    user.LastName = model.LastName;
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
            
        // GET: Application/User/Profile/5
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
                Firtname = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = _addressManager.GetAddress((int)user.AddressId)
            };
            
            return View(model);
        }

        // POST: Application/User/Profile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(int id, UserViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id.ToString());
                    user.FirstName = model.Firtname;
                    user.LastName = model.LastName;
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

        // GET: Application/User/Delete/5
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

        // POST: Application/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
            // await _userManager.DeleteAsync(applicationUser);
            applicationUser.Status = false;
            await _userManager.UpdateAsync(applicationUser);
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _userManager.Users.Any(e => e.Id == id);
        }
    }
}
