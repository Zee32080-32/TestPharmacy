using Microsoft.AspNetCore.Identity;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public class FeedbackFormService : IFeedbackFormService<FeedBackFormViewModel>
    {
        private readonly IRepository<FeedbackForm> _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FeedbackFormService(IRepository<FeedbackForm> repository, UserManager<IdentityUser> userManager,
             IHttpContextAccessor httpContextAccessor)
        { 
            _repository = repository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<FeedBackFormViewModel> CreateForm(FeedBackFormViewModel entity)
        {

            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                throw new Exception("User context is null.");

            var userId = _userManager.GetUserId(user); 
            var newModel = new FeedbackForm
            {
                Title = entity.Title,
                Description = entity.Description,
                CustomerID = userId
            };

            await _repository.AddAsync(newModel);

            //map it back onto the vm so I dont talk to the db 
            var vm = new FeedBackFormViewModel
            {
                Title = newModel.Title,
                Description = newModel.Description,
            };

            return vm;

        }

        public async Task<FeedBackFormViewModel> DeleteFromForm(int formId)
        {
            await _repository.DeleteAsync(formId);
            return null;
        }
        public async Task<IEnumerable<FeedBackFormViewModel>> ReadForms()
        {

            var forms = await _repository.GetAllAsync();

            // Map the entities to FeedBackFormViewModel
            var formViewModels = forms.Select(form => new FeedBackFormViewModel
            {
                Title = form.Title,
                Description = form.Description,

            });

            return formViewModels;
        }

        public Task<FeedBackFormViewModel> UpdateToForm()
        {
            throw new NotImplementedException();
        }
    }
}
