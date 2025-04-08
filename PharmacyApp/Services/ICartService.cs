using PharmacyApp.Models;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public interface ICartService<T> where T : class
    {
        Task AddToCartAsync(int productId, int customerId, int quantity);
        Task<IEnumerable<Cart>> GetCartItemsAsync(int customerId);
        Task RemoveFromCartAsync(int cartId);
        Task UpdateCartItemQuantityAsync(int cartId, int quantity);
        decimal CalculateTotalPrice(IEnumerable<Cart> cartItems);
    }
}
