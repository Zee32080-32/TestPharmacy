using PharmacyApp.ViewModels;
using System.Collections;

namespace PharmacyApp.Services
{
    public interface IProductService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllProductsAsync();

        Task<T> GetProductByID(int id);

        Task<IEnumerable<T>> GetAllProductsByCategory(string category);

        Task<IEnumerable<T>> SearchForProductByName(string productName);
        Task<T> getProductByName(string Name);
        Task<T> purchaseProduct(string Name);

        Task<IEnumerable<T>> GetTop3Products();
        Task<T> GetProductByIdAsync(int id);
    }
}
