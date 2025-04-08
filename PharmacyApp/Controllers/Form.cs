using Microsoft.AspNetCore.Mvc;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Controllers
{
    public class Form : Controller
    {
        private readonly IFeedbackFormService<FeedBackFormViewModel> _feedbackFormService;
        private readonly IRepository<FeedbackForm> _feedbackRepository;

        public Form(IFeedbackFormService<FeedBackFormViewModel> feedbackFormService, IRepository<FeedbackForm> feedbackRepository)
        {
            _feedbackFormService = feedbackFormService;
            _feedbackRepository = feedbackRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var forms = await _feedbackRepository.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> DeleteForm(int id)
        {
            await _feedbackRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateForm(FeedBackFormViewModel viewModel)
        {
            var create = await _feedbackFormService.CreateForm(viewModel);

            return RedirectToAction("Index");

        }
    }
}
