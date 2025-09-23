namespace API.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int? AddidtionalStock { get; set; }

        public Product Product { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}