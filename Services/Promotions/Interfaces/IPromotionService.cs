using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.DTO.Promotions;

namespace promotion_net.Services.Promotions.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionDto>> GetAllAsync();
        Task<PromotionDto?> GetByIdAsync(Guid id);
        Task<PromotionDto> CreateAsync(CreatePromotionDto dto);
        Task<PromotionDto> UpdateAsync(Guid id, UpdatePromotionDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<decimal> ApplyPromotionAsync(ApplyPromotionDto dto);
        Task<bool> AddProductsToPromotionAsync(AddPromotionToProducts dto);
    }
}