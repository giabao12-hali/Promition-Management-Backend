using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using promotion_net.Data;
using promotion_net.DTO.Promotions;
using promotion_net.Models.PromotionProducts;
using promotion_net.Models.Promotions;
using promotion_net.Services.Promotions.Interfaces;

namespace promotion_net.Services.Promotions.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly ApplicationDbContext _context;

        public PromotionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductsToPromotionAsync(AddPromotionToProducts dto)
        {
            // tìm mã sản phẩm
            var promotion = await _context.Promotions
                .Include(p => p.PromotionProducts)
                .FirstOrDefaultAsync(p => p.Id == dto.PromotionId);
            if (promotion == null)
                throw new Exception("Mã khuyến mãi không tồn tại");

            // lọc các sản phẩm hợp lệ
            var validProducts = await _context.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();
            if (!validProducts.Any())
                throw new Exception("Không có sản phẩm hợp lệ để thêm vào khuyến mãi");

            // tạo list quan hệ mới
            foreach (var product in validProducts)
            {
                if (promotion.PromotionProducts.Any(pp => pp.ProductId == product.Id))
                    continue; // bỏ qua sản phẩm đã có trong khuyến mãi

                promotion.PromotionProducts.Add(new PromotionProduct
                {
                    ProductId = product.Id,
                    PromotionId = promotion.Id
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> ApplyPromotionAsync(ApplyPromotionDto dto)
        {
            // tìm mã khuyến mãi theo code
            var promotion = await _context.Promotions
                .Include(p => p.PromotionProducts)
                .FirstOrDefaultAsync(p => p.Code == dto.PromotionCode && p.IsActive);

            if (promotion == null)
                throw new Exception("Mã khuyến mãi không tồn tại hoặc đã hết hạn");

            // kiểm tra ngày hiệu lực
            if (DateTime.UtcNow < promotion.StartDate || DateTime.UtcNow > promotion.EndDate)
                throw new Exception("Mã khuyến mãi chưa đến hạn hoặc không còn hiệu lực");

            // kiểm tra sản phẩm có mã khuyến mãi không
            bool isApplied = promotion.PromotionProducts.Any(pp => pp.ProductId == dto.ProductId);
            if (!isApplied)
                throw new Exception("Sản phẩm không áp dụng mã khuyến mãi này");

            // lấy giá sản phẩm
            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null)
                throw new Exception("Sản phẩm không tồn tại");

            // tính toán giá sau khi áp dụng khuyến mãi
            var discountAmount = product.Price * promotion.DiscountPercent / 100;
            var finalPrice = product.Price - discountAmount;

            return finalPrice;
        }

        public async Task<PromotionDto> CreateAsync(CreatePromotionDto dto)
        {
            var promotions = new Promotion
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                DiscountPercent = dto.DiscountPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            _context.Promotions.Add(promotions);
            await _context.SaveChangesAsync();

            return new PromotionDto
            {
                Id = promotions.Id,
                Name = promotions.Name,
                Code = promotions.Code,
                DiscountPercent = promotions.DiscountPercent,
                StartDate = promotions.StartDate,
                EndDate = promotions.EndDate,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var promotions = await _context.Promotions.FindAsync(id);
            if (promotions == null) return false;

            _context.Promotions.Remove(promotions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PromotionDto>> GetAllAsync()
        {
            var promotions = await _context.Promotions.ToListAsync();
            return promotions.Select(p => new PromotionDto
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Description = p.Description,
                DiscountPercent = p.DiscountPercent,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                IsActive = p.IsActive
            });
        }

        public async Task<PromotionDto?> GetByIdAsync(Guid id)
        {
            var promotions = await _context.Promotions.FindAsync(id);
            if (promotions == null) return null;
            return new PromotionDto
            {
                Id = promotions.Id,
                Name = promotions.Name,
                Code = promotions.Code,
                Description = promotions.Description,
                DiscountPercent = promotions.DiscountPercent,
                StartDate = promotions.StartDate,
                EndDate = promotions.EndDate,
                IsActive = promotions.IsActive
            };
        }

        public async Task<PromotionDto> UpdateAsync(Guid id, UpdatePromotionDto dto)
        {
            var promotions = await _context.Promotions.FindAsync(id);
            if (promotions == null) throw new Exception("Promotion not found");

            promotions.Name = dto.Name ?? promotions.Name;
            promotions.Code = dto.Code ?? promotions.Code;
            promotions.DiscountPercent = dto.DiscountPercent;
            promotions.StartDate = dto.StartDate;
            promotions.EndDate = dto.EndDate;

            _context.Promotions.Update(promotions);
            await _context.SaveChangesAsync();

            return new PromotionDto
            {
                Id = promotions.Id,
                Name = promotions.Name,
                Code = promotions.Code,
                DiscountPercent = promotions.DiscountPercent,
                StartDate = promotions.StartDate,
                EndDate = promotions.EndDate,
            };
        }
    }
}