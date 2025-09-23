using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? DeliveryFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? SalesTax { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }
        public int? PromoCodeId { get; set; }

        public User? User { get; set; }
        public PromoCode? PromoCode { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}