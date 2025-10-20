using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Promotions
{
    public class AddPromotionToProducts
    {
        public Guid PromotionId { get; set; }
        public List<Guid> ProductIds { get; set; } = new();
    }
}