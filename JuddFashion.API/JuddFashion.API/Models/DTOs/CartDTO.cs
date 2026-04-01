namespace JuddFashion.API.Models.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }
    }
}
