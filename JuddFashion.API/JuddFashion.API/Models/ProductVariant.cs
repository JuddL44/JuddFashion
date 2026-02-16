namespace JuddFashion.API.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public ClothingSize Size { get; set; }
        public string Color { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal? PriceAdjustment { get; set; }
    }
}
