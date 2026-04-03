namespace JuddFashion.API.Models.DTOs
{
    public class CheckoutResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> OutOfStockItems { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}