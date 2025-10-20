using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.Promotions;

namespace promotion_net.Helpers.Products
{
    public static class PriceHelper
    {
        public static decimal CalculateFinalPrice(decimal basePrice, List<Promotion> promotions)
        {
            if (promotions == null || !promotions.Any()) return basePrice;

            decimal discounted = basePrice;
            foreach (var promo in promotions)
            {
                if (promo.IsActive && promo.StartDate <= DateTime.UtcNow && promo.EndDate >= DateTime.UtcNow)
                {
                    discounted -= basePrice * (promo.DiscountPercent / 100);
                }
            }
            return discounted < 0 ? 0 : discounted;
        }
    }
}