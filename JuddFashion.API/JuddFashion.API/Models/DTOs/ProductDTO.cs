namespace JuddFashion.API.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
        public List<ProductVariantDTO> Variants { get; set; } = new List<ProductVariantDTO>();

        // Computed properties for convenience
        public int TotalStock => Variants.Sum(v => v.StockQuantity);

        public bool IsAvailable => Variants.Any(v => v.InStock);
        public List<string> AvailableColors => Variants.Where(v => v.InStock).Select(v => v.Color).Distinct().ToList();
        public List<string> AvailableSizes => Variants.Where(v => v.InStock).Select(v => v.Size).Distinct().ToList();
    }
}