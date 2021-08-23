using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using PharmacyManagmentV2.Models;
//23.08.2021- 15.00
namespace PharmacyManagmentV2.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IGenericRepository<Address> _address;
        private readonly ILogger<UserController> _logger;

        public UserController(AppDBContext context,
                            UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IGenericRepository<Address> address,
                            RoleManager<ApplicationRole> roleManager,
                            ILogger<UserController> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _address = address;
            _roleManager = roleManager;
            _logger = logger;
        }

        // GET: Application/User
        [ActionName("Index")]
        [Authorize(Roles = "List User")]
        public async Task<IActionResult> Index()
        {

            var appDBContext = _context.ApplicationUsers.Include(a => a.Address);
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


            if (ModelState.IsValid)
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
        [Authorize(Roles ="Register")]
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

                await _address.Create(model.Address);
                var user = new ApplicationUser
                {
                    FirstName = model.Firtname,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName=model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserType = model.UserType,
                    Address = model.Address
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

            var applicationUser = await _context.ApplicationUsers
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

            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            var model = new RegisterViewModel()
            {
                Firtname =user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                Address = _address.GetAll().FirstOrDefault(p=>p.Id==user.AddressId)
            };
            
            return View(model);
        }

        // POST: Application/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, RegisterViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    await _address.Update(model.Address);
                    _context.Update(model);
                    await _context.SaveChangesAsync();
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

            var applicationUser = await _context.ApplicationUsers
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
            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(int id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
