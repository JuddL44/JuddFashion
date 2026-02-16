namespace JuddFashion.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; } 
        public ClothingCategory Category { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true; 
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
