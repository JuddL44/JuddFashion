using JuddFashion.API.Models.DTOs;

namespace JuddFashion.API.Services
{
    public interface ICartService
    {
        Task<CartDTO?> GetUserCart(int userId);

        Task<CartDTO?> AddToCart(int userId, AddToCartDTO addToCartDTO);

        Task<CartDTO?> UpdateCartItem(int userId, int cartItemId, int quantity);

        Task<bool> RemoveFromCart(int userId, int cartItemId);

        Task<bool> ClearCart(int userId);

        Task<CheckoutResultDTO> Checkout(int userId);
    }
}