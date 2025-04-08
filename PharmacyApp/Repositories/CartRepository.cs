using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;
using PharmacyApp.Models;
using PharmacyApp.ViewModels;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationdbContext _context;

        public CartRepository(ApplicationdbContext context)
        {
            _context = context;
        }

        // Method to add a product to the cart
        public async Task AddToCartAsync(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        // method to get all cart items for a customer
        public async Task<IEnumerable<Cart>> GetCartItemsByCustomerIdAsync(int customerId)
        {
            return await _context.Cart
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Product) 
                .ToListAsync();
        }

        // method to remove an item from the cart
        public async Task RemoveFromCartAsync(int cartId)
        {
            var cartItem = await _context.Cart.FindAsync(cartId);
            if (cartItem != null)
            {
                _context.Cart.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        // method to update the quantity of a product in the cart
        public async Task UpdateCartItemQuantityAsync(int cartId, int quantity)
        {
            var cartItem = await _context.Cart.FindAsync(cartId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                cartItem.TotalPrice = cartItem.Product.Price * quantity;
                await _context.SaveChangesAsync();
            }
        }

        // method to check if the product is already in the cart for a customer
        public async Task<Cart> GetCartItemByProductAndCustomerAsync(int productId, int customerId)
        {
            return await _context.Cart
                .Where(c => c.productId == productId && c.CustomerId == customerId)
                .FirstOrDefaultAsync();
        }
    }
}
