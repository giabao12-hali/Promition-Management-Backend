using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Promotions
{
    public class PromotionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}