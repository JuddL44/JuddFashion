namespace JuddFashion.API.Models.DTOs
{
    public class AddToCartDTO
    {
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}