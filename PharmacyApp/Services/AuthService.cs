using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    /// <summary>
    /// communicates with viewmodel as you dont want to interact with the database and 
    /// this class will interact with the Accountcontroller whhich is linked to the chtml which uses the viewmodel
    /// </summary>
    public class AuthService : IAuthService<CustomerViewModel>
    {
        private readonly IRepository<Customers> _customerRepository;

        private readonly PasswordHasher<Customers> _hasher;
        public AuthService(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
            _hasher = new PasswordHasher<Customers>();
        }

        public async Task<CustomerViewModel> ValidateLoginAsync(string email, string password)
        {
            var user = await _customerRepository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new Exception();

            } 

            
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            { 
                return new CustomerViewModel
                {
                    CustomerId = user.CustomerId,
                    Email = user.Email,
                };
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<(bool Success, string Error)> RegisterUserAsync(CustomerViewModel model)
        {
            var existingCustomer = await _customerRepository.GetByEmailAsync(model.Email);
            if (existingCustomer != null)
            { 
                return (false, "Email already exists.");
            }

            if (model.Password != model.PasswordConfirmed)
            { 
                return (false, "Passwords do not match.");
            }

            var customer = new Customers
            {
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            customer.PasswordHash = _hasher.HashPassword(customer, model.Password);
            await _customerRepository.AddAsync(customer);

            return (true, string.Empty);
        }
    }
}
