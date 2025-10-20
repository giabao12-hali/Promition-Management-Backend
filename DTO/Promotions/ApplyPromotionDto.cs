using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Promotions
{
    public class ApplyPromotionDto
    {
        public string PromotionCode { get; set; } = string.Empty;
        public Guid ProductId { get; set; }
    }
}