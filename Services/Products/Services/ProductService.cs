using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using promotion_net.Data;
using promotion_net.DTO.Categories;
using promotion_net.DTO.Products;
using promotion_net.DTO.Promotions;
using promotion_net.Helpers.Products;
using promotion_net.Models.Categories;
using promotion_net.Models.Products;
using promotion_net.Models.PromotionProducts;
using promotion_net.Services.Products.Interfaces;

namespace promotion_net.Services.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                Price = dto.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = dto.IsActive,
                CategoryId = dto.CategoryId,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.PromotionProducts)
                .ThenInclude(pp => pp.Promotion)
                .ToListAsync();

            return products.Select(p =>
            {
                var activePromotion = p.PromotionProducts
                    .Select(pp => pp.Promotion)
                    .FirstOrDefault(pr =>
                        pr.IsActive &&
                        pr.StartDate <= DateTime.UtcNow &&
                        pr.EndDate >= DateTime.UtcNow);

                var discountPercent = activePromotion?.DiscountPercent ?? 0;
                var finalPrice = p.Price * (1 - discountPercent / 100);

                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Description = p.Description,
                    Price = p.Price,
                    FinalPrice = finalPrice,
                    AppliedPromotionCode = activePromotion?.Code,
                    AppliedPromotionCodes = p.PromotionProducts
                        .Select(pp => pp.Promotion.Code)
                        .ToList(),
                    Promotion = activePromotion == null ? null : new PromotionDto
                    {
                        Id = activePromotion.Id,
                        Name = activePromotion.Name,
                        Code = activePromotion.Code,
                        Description = activePromotion.Description,
                        DiscountPercent = activePromotion.DiscountPercent,
                        StartDate = activePromotion.StartDate,
                        EndDate = activePromotion.EndDate,
                        IsActive = activePromotion.IsActive
                    },
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Category = p.Category == null ? null : new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description,
                    },
                };
            });
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId,
                Category = product.Category == null ? null : new CategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    Description = product.Category.Description,
                },
            };
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _context.Products
                .Include(p => p.PromotionProducts)
                .ThenInclude(pp => pp.Promotion)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) throw new KeyNotFoundException("Product not found");

            product.Name = dto.Name;
            product.Code = dto.Code;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.IsActive = dto.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
            product.CreatedAt = product.CreatedAt;
            product.CategoryId = dto.CategoryId;

            _context.PromotionProducts.RemoveRange(product.PromotionProducts);

            if (dto.PromotionIds != null && dto.PromotionIds.Any())
            {
                product.PromotionProducts = dto.PromotionIds
                    .Select(pid => new PromotionProduct
                    {
                        ProductId = product.Id,
                        PromotionId = pid
                    }).ToList();
            }

            await _context.SaveChangesAsync();

            // tính giá khuyến mãi
            var promotions = product.PromotionProducts.Select(pp => pp.Promotion).ToList();
            var finalPrice = PriceHelper.CalculateFinalPrice(product.Price, promotions);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId,
                Category = product.Category == null ? null : new CategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    Description = product.Category.Description
                },
                FinalPrice = finalPrice,
                AppliedPromotionCodes = promotions.Select(p => p.Code).ToList()
            };
        }
    }
}