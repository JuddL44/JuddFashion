using JuddFashion.API.Data;
using JuddFashion.API.Models;
using JuddFashion.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JuddFashion.API.Services
{
    public class CartService : ICartService
    {
        public readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CartDTO?> AddToCart(int userId, AddToCartDTO addToCartDTO)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductVariantId == addToCartDTO.ProductVariantId);

            if (existingItem != null)
            {
                existingItem.Quantity += addToCartDTO.Quantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductVariantId = addToCartDTO.ProductVariantId,
                    Quantity = addToCartDTO.Quantity
                };
                cart.CartItems.Add(cartItem);
            }

            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.ProductVariant).ThenInclude(pv => pv.Product).FirstOrDefaultAsync(c => c.Id == cart.Id);
            return MapToCartDTO(cart!);
        }

        public async Task<bool> ClearCart(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null) { return false; }

            cart.CartItems.Clear();
            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CartDTO?> GetUserCart(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.ProductVariant).ThenInclude(pv => pv.Product).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            return MapToCartDTO(cart);
        }

        public async Task<bool> RemoveFromCart(int userId, int cartItemId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null) { return false; }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem == null) { return false; }

            cart.CartItems.Remove(cartItem);
            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CartDTO?> UpdateCartItem(int userId, int cartItemId, int quantity)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null) { return null; }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem == null) { return null; }

            if (quantity <= 0)
            {
                cart.CartItems.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.ProductVariant).ThenInclude(pv => pv.Product).FirstOrDefaultAsync(c => c.Id == cart.Id);

            return MapToCartDTO(cart!);
        }

        public async Task<CheckoutResultDTO> Checkout(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.ProductVariant).ThenInclude(pv => pv.Product).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null || !cart.CartItems.Any())
            {
                return new CheckoutResultDTO { Success = false, Message = "Cart is empty." };
            }
            ;
            var outOfStockItems = new List<string>();

            foreach (var item in cart.CartItems)
            {
                if (item.Quantity > item.ProductVariant.StockQuantity)
                {
                    outOfStockItems.Add($"{item.ProductVariant.Product.Name} ({item.ProductVariant.Size}, {item.ProductVariant.Color})");
                }
            }

            if (outOfStockItems.Any())
            {
                return new CheckoutResultDTO
                {
                    Success = false,
                    Message = "Some items are out of stock: " + string.Join(", ", outOfStockItems)
                };
            }

            decimal totalAmount = 0;

            foreach (var item in cart.CartItems)
            {
                item.ProductVariant.StockQuantity -= item.Quantity;
                totalAmount += (item.ProductVariant.Product.BasePrice + (item.ProductVariant.PriceAdjustment ?? 0m)) * item.Quantity;
            }

            cart.CartItems.Clear();
            cart.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new CheckoutResultDTO
            {
                Success = true,
                Message = "Order placed successfully!",
                TotalAmount = totalAmount
            };
        }

        private CartDTO MapToCartDTO(Cart cart)
        {
            var items = cart.CartItems.Select(ci => new CartItemDTO
            {
                Id = ci.Id,
                ProductVariantId = ci.ProductVariantId,
                Quantity = ci.Quantity,
                Category = ci.ProductVariant.Product.Category.ToString(),
                Brand = ci.ProductVariant.Product.Brand,
                ProductName = ci.ProductVariant.Product.Name,
                ProductDescription = ci.ProductVariant.Product.Description,
                ProductImageUrl = ci.ProductVariant.Product.ImageUrl,
                Size = ci.ProductVariant.Size.ToString(),
                Color = ci.ProductVariant.Color,
                Price = ci.ProductVariant.Product.BasePrice + (ci.ProductVariant.PriceAdjustment ?? 0m),
                StockQuantity = ci.ProductVariant.StockQuantity
            }).ToList();

            return new CartDTO
            {
                Id = cart.Id,
                Items = items,
                TotalPrice = items.Sum(i => i.Price * i.Quantity),
                TotalItems = items.Sum(i => i.Quantity)
            };
        }
    }
}