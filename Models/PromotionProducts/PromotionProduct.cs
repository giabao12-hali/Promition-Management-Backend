using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.Products;
using promotion_net.Models.Promotions;

namespace promotion_net.Models.PromotionProducts
{
    public class PromotionProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public Guid PromotionId { get; set; }
        public Promotion Promotion { get; set; } = default!;
    }
}