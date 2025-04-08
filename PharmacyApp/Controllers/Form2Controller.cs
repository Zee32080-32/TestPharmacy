using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Controllers
{
    public class Form2Controller : Controller
    {
        private IForm2Service<Form2ViewModel> _form2Service;

        public Form2Controller(IForm2Service<Form2ViewModel> form2Service)
        {


            _form2Service = form2Service;
        }

        // This method checks for CustomerId in the session before allowing any action to proceed
        private bool CheckCustomerSession()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId.HasValue)
            {
                ViewData["CustomerId"] = customerId.Value;
                return true;
            }
            else
            {
                // If no CustomerId in session, redirect to login
                return false;
            }
        }

        public async Task< IActionResult> Index()
        {
            /*
            if (!CheckCustomerSession())
            {
                return RedirectToAction("Login", "Account"); // Redirect if session is not valid
            }
            */

            var allItems = await _form2Service.GetAllAsync();
            return View(allItems);
        }


        public async Task<IActionResult> CreateForm(Form2ViewModel viewModel)
        {
            //var customerId = HttpContext.Session.GetInt32("CustomerId");
            //viewModel.CustomerId = customerId.Value;

            await _form2Service.CreateAsync(viewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditForm(Form2ViewModel viewModel)
        { 
            await _form2Service.UpdateAsync(viewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteForm(int id)
        {
            await _form2Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DisplayAll()
        { 
            await _form2Service.GetAllAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReadOne(int id)
        {
            await _form2Service.ReadOneAsync(id);
            return RedirectToAction("Index");
        }

    }
}
