using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Promotions
{
    public class CreatePromotionDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Code { get; set; } = string.Empty;
        [StringLength(500)]
        public string? Description { get; set; }
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        public decimal DiscountPercent { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}