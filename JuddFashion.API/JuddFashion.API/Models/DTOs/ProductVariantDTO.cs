namespace JuddFashion.API.Models.DTOs
{
    public class ProductVariantDTO
    {
        public int Id { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal? PriceAdjustment { get; set; }
        public decimal FinalPrice { get; set; }
        public bool InStock => StockQuantity > 0;
    }
}
