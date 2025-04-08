using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public interface IAuthService<T> where T : class
    {
        Task<CustomerViewModel> ValidateLoginAsync(string email, string password);

        Task<(bool Success, string Error)> RegisterUserAsync(T model);
    }
}
