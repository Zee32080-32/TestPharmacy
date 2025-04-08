using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Data;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService<CustomerViewModel> _authService;

        public AccountController(IAuthService<CustomerViewModel> authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();

        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Keep login-related fields only
          
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }

            try
            {
                // Call the ValidateLoginAsync method from  AuthService
                var customerViewModel = await _authService.ValidateLoginAsync(email, password);

                // If the login is successful, redirect the user to their dashboard or a success page
               
                HttpContext.Session.SetInt32("CustomerId", customerViewModel.CustomerId);

               

                return RedirectToAction("Index", "Form2");
            }
            catch (Exception ex)
            {
               
                //error msg
                TempData["ErrorMessage"] = "Invalid login credentials. Please try again.";
                return View();  
            }



        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, error) = await _authService.RegisterUserAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction("Login");
        }
    }
}
