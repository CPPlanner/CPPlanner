using CPPlanner.Models;
using CPPlanner.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<CPPlannerUser> _signInManager;
        private UserManager<CPPlannerUser> _userManager;

        public AuthController(SignInManager<CPPlannerUser> signInManager, UserManager<CPPlannerUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Home", "App");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }
            return View();
        }
        
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new CPPlannerUser()
                {
                    FirstName = vm.FirstName.Trim(),
                    LastName = vm.LastName.Trim(),
                    UserName = vm.Username.Trim(),                    
                    Email = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    // Authenticate user and redirect to Home page
                    await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                    return RedirectToAction("Home", "App");
                }
                else
                {
                    List<IdentityError> errors = result.Errors.ToList();
                    foreach (IdentityError err in errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }                    
                }
            }
            else
            {
                ModelState.AddModelError("", "Some data fields are invalid.");                
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "App");
        }
    }
}
