using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.Categories;
using promotion_net.Models.PromotionProducts;

namespace promotion_net.Models.Products
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; } = default!;
        public ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();
    }
}