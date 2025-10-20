using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.DTO.Categories;
using promotion_net.DTO.Promotions;
using promotion_net.Models.Categories;

namespace promotion_net.DTO.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? FinalPrice { get; set; } // giá sau khi áp dụng khuyến mãi
        public string? AppliedPromotionCode { get; set; } // mã khuyến mãi đã áp dụng
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public PromotionDto? Promotion { get; set; }
        public List<string>? AppliedPromotionCodes { get; set; } = new();
    }
}