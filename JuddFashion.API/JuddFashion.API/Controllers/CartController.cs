using JuddFashion.API.Models.DTOs;
using JuddFashion.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JuddFashion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController: ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet] // - /api/cart
        public async Task<ActionResult<CartDTO>> GetCart()
        {
            var userId = GetUserId();
            var cart = await _cartService.GetUserCart(userId);
            if (cart == null) { return NotFound(); }
            return Ok(cart);
        }

        [HttpPost] // - /api/cart
        public async Task<ActionResult<CartDTO>> AddToCart(AddToCartDTO addToCartDTO)
        {
            var userId = GetUserId();
            var cart = await _cartService.AddToCart(userId, addToCartDTO);
            if (cart == null) { return BadRequest(new { message = "Failed to add item to cart" }); }
            return Ok(cart);
        }


        [HttpPut("{cartItemId}")] // - /api/cart/(cartItemId)
        public async Task<ActionResult<CartDTO>> UpdateCartItem(int cartItemId, [FromQuery] int quantity)
        {
            var userId = GetUserId();
            var cart = await _cartService.UpdateCartItem(userId, cartItemId, quantity);
            if (cart == null) { return BadRequest(new { message = "Cart item not found" }); }
            return Ok(cart);
        }


        [HttpDelete("{cartItemId}")] // - /api/cart/(cartItemId)
        public async Task<ActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = GetUserId();
            var success = await _cartService.RemoveFromCart(userId, cartItemId);
            if (!success) { return BadRequest(new { message = "Cart item not found" }); }
            return NoContent();
        }


        [HttpDelete("clear")]
        public async Task<ActionResult> ClearCart()
        {
            var userId = GetUserId();
            await _cartService.ClearCart(userId);
            return NoContent();
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim!);
        }
    }
}
