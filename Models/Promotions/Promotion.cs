using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.PromotionProducts;

namespace promotion_net.Models.Promotions
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();
    }
}