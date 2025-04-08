using PharmacyApp.Models;

namespace PharmacyApp.Repositories
{
    public interface ICartRepository
    {
        Task AddToCartAsync(Cart cart);
        Task<IEnumerable<Cart>> GetCartItemsByCustomerIdAsync(int customerId);
        Task RemoveFromCartAsync(int cartId);
        Task UpdateCartItemQuantityAsync(int cartId, int quantity);
        Task<Cart> GetCartItemByProductAndCustomerAsync(int productId, int customerId);
    }
}
