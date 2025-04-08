using Microsoft.AspNetCore.Cors.Infrastructure;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;
using static PharmacyApp.Helpers.SessionExtensions;
using Microsoft.AspNetCore.Session;
using PharmacyApp.Repositories;
using PharmacyApp.Models;

public class CartService : ICartService<CartViewModel>
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    // method to add a product to the cart
    public async Task AddToCartAsync(int productId, int customerId, int quantity)
    {
        var existingCartItem = await _cartRepository.GetCartItemByProductAndCustomerAsync(productId, customerId);

        // If the product is already in the cart, update the quantity
        if (existingCartItem != null)
        {
            await _cartRepository.UpdateCartItemQuantityAsync(existingCartItem.cartId, existingCartItem.Quantity + quantity);
        }
        else
        {
            var product = new Cart
            {
                productId = productId,
                CustomerId = customerId,
                Quantity = quantity,
                TotalPrice = quantity * GetProductPriceById(productId) 
            };

            await _cartRepository.AddToCartAsync(product);
        }
    }

    // method to get all cart items for a customer
    public async Task<IEnumerable<Cart>> GetCartItemsAsync(int customerId)
    {
        return await _cartRepository.GetCartItemsByCustomerIdAsync(customerId);
    }

    // method to remove a product from the cart
    public async Task RemoveFromCartAsync(int cartId)
    {
        await _cartRepository.RemoveFromCartAsync(cartId);
    }

    // method to update the quantity of a cart item
    public async Task UpdateCartItemQuantityAsync(int cartId, int quantity)
    {
        await _cartRepository.UpdateCartItemQuantityAsync(cartId, quantity);
    }

    // method to calculate the total price of the cart
    public decimal CalculateTotalPrice(IEnumerable<Cart> cartItems)
    {
        decimal totalPrice = 0;
        foreach (var item in cartItems)
        {
            totalPrice += item.TotalPrice;
        }
        return totalPrice;
    }

    // helper method to get the product price by ID (you might need to adjust this based on your implementation)
    private decimal GetProductPriceById(int productId)
    {
    
   
        return 19.99m; 
    }
}



