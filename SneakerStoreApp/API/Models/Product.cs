using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SneakerStoreApp.API.Models;

namespace SneakerStoreApp.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public string BrandName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal RegularPrice { get; set; }

        public decimal? SalePrice { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public string MainImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}