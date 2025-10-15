using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using promotion_net.Data;
using promotion_net.DTO.Categories;
using promotion_net.Models.Categories;
using promotion_net.Services.Categories.Interfaces;

namespace promotion_net.Services.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = createCategoryDto.Name,
                Code = createCategoryDto.Code,
                Description = createCategoryDto.Description,
                ParentId = createCategoryDto.ParentId
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Description = category.Description,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Description = c.Description
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null) return null;

            return new CategoryDto
            {
                Id = categories.Id,
                Name = categories.Name,
                Code = categories.Code,
                Description = categories.Description
            };
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Category not found");

            category.Name = updateCategoryDto.Name;
            category.Code = updateCategoryDto.Code;
            category.Description = updateCategoryDto.Description;
            category.ParentId = updateCategoryDto.ParentId;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Description = category.Description,
            };
        }
    }
}