using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using promotion_net.Models.Categories;
using promotion_net.Models.Products;
using promotion_net.Models.PromotionProducts;
using promotion_net.Models.Promotions;
using promotion_net.Models.Users;

namespace promotion_net.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PromotionProduct> PromotionProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration if needed

            // Seed User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "nguyenhiengiabao12@gmail.com",
                    FullName = "Nguyen Hien Gia Bao",
                    PhoneNumber = "0123456789",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("giabao1203"), // Hash the password
                    Role = Enum.RoleType.Admin,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // mối quan hệ của product - promotions
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PromotionProduct>()
                .HasKey(pp => new { pp.ProductId, pp.PromotionId });

            modelBuilder.Entity<PromotionProduct>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<PromotionProduct>()
                .HasOne(pp => pp.Promotion)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.PromotionId);

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Code = "CAT001",
                    Name = "Điện thoại",
                    Description = "Các loại điện thoại thông minh.",
                    ParentId = null
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Code = "CAT002",
                    Name = "Laptop",
                    Description = "Các loại máy tính xách tay.",
                    ParentId = null
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Code = "CAT003",
                    Name = "Phụ kiện",
                    Description = "Các loại phụ kiện điện tử.",
                    ParentId = null
                }
            );

            // seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "iPhone 16 Pro",
                    Code = "P001",
                    Description = "Điện thoại iPhone 16 Pro mới nhất với nhiều tính năng vượt trội.",
                    Price = 1000000,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung Galaxy S24 Ultra",
                    Code = "P002",
                    Description = "Điện thoại Samsung Galaxy S24 Ultra với camera chất lượng cao.",
                    Price = 900000,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Google Pixel 8 Pro",
                    Code = "P003",
                    Description = "Điện thoại Google Pixel 8 Pro với trải nghiệm Android thuần túy.",
                    Price = 800000,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Id = Guid.NewGuid(),
                    Code = "PROMO10",
                    Name = "Giảm giá 10%",
                    Description = "Giảm giá 10% cho tất cả các sản phẩm trong dịp lễ.",
                    DiscountPercent = 10,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    IsActive = true
                },
                new Promotion
                {
                    Id = Guid.NewGuid(),
                    Code = "PROMO20",
                    Name = "Giảm giá 20%",
                    Description = "Giảm giá 20% cho các sản phẩm điện thoại cao cấp.",
                    DiscountPercent = 20,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    IsActive = true
                },

                new Promotion
                {
                    Id = Guid.NewGuid(),
                    Code = "WELCOME15",
                    Name = "Giảm giá 15%",
                    Description = "Chào mừng bạn mới đến với cửa hàng, giảm giá 15% cho đơn hàng đầu tiên.",
                    DiscountPercent = 15,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    IsActive = true
                }
            );
        }
    }
}