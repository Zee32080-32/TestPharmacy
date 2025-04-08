using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public class PaymentService : IPaymentService<PaymentViewModel>
    {
        private readonly IRepository<Payments> _paymentRepository;
        private readonly IRepository<Customers> _customerRepository;


        public PaymentService(IRepository<Payments> paymentRepository, IRepository<Customers> customerRepository)
        {
            _paymentRepository = paymentRepository;
            _customerRepository = customerRepository;

        }
        public async Task<PaymentViewModel> CreatePaymentEntry(string productName, string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            var prodcut = await _paymentRepository.GetByNameAsync(productName);

            if(customer == null) 
            {
                throw new Exception();

            }

            var Payment = new Payments
            {
                CustomerId = customer.CustomerId,
                PaymentDate = prodcut.PaymentDate,
                Amount = prodcut.Amount,
                PaymentStatus = "Paid", 
            };

            // save to DB
            await _paymentRepository.AddAsync(Payment);

            var payment = new PaymentViewModel
            {
                CustomerId = customer.CustomerId,
                Customer = customer,
                PaymentDate = prodcut.PaymentDate,
                Amount = prodcut.Amount,
                PaymentStatus = "paid",
            };
            return payment;
        }

        public Task<PaymentViewModel> CreatePaymentEntry()
        {
            throw new NotImplementedException();
        }
    }
}
