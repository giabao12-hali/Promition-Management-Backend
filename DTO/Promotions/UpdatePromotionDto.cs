using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Promotions
{
    public class UpdatePromotionDto
    {
        [Required]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, 100)]
        public decimal? DiscountPercent { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
    }
}