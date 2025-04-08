namespace PharmacyApp.Services
{
    public interface IPaymentService<T> where T : class
    {
        Task<T> CreatePaymentEntry(string productName, string email);
    }
}
