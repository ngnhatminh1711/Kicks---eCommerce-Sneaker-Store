using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public string DiscountType { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountValue { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? MinOrderAmount { get; set; }

        public bool? IsActive { get; set; }
        
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}