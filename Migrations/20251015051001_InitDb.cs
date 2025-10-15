using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace promotion_net.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionProducts", x => new { x.ProductId, x.PromotionId });
                    table.ForeignKey(
                        name: "FK_PromotionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionProducts_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("7e992b46-29c8-42c9-8bd2-fb28705e12c3"), "CAT002", "Các loại máy tính xách tay.", "Laptop", null },
                    { new Guid("a5722d32-f250-4fb5-93ff-b3df0beb9885"), "CAT001", "Các loại điện thoại thông minh.", "Điện thoại", null },
                    { new Guid("d38777bb-4c6a-4098-beae-8e22e2590e84"), "CAT003", "Các loại phụ kiện điện tử.", "Phụ kiện", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedAt", "Description", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7f8c053f-5705-4862-bd79-183e43d0a29c"), null, "P003", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1224), "Điện thoại Google Pixel 8 Pro với trải nghiệm Android thuần túy.", true, "Google Pixel 8 Pro", 800000m, new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1215) },
                    { new Guid("a8d655e5-de45-489c-9a71-fbf7530433a5"), null, "P001", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1211), "Điện thoại iPhone 16 Pro mới nhất với nhiều tính năng vượt trội.", true, "iPhone 16 Pro", 1000000m, new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1203) },
                    { new Guid("cd18fb4f-91ef-4adc-bde6-f0d9ebd6f317"), null, "P002", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1214), "Điện thoại Samsung Galaxy S24 Ultra với camera chất lượng cao.", true, "Samsung Galaxy S24 Ultra", 900000m, new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1212) }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "Description", "DiscountPercent", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("1dc231f7-29e5-478d-bb41-2c1038438ed4"), "WELCOME15", "Chào mừng bạn mới đến với cửa hàng, giảm giá 15% cho đơn hàng đầu tiên.", 15m, new DateTime(2025, 11, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1265), true, "Giảm giá 15%", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1265) },
                    { new Guid("24ee8686-8beb-48cf-a0e8-2dc3e9255541"), "PROMO20", "Giảm giá 20% cho các sản phẩm điện thoại cao cấp.", 20m, new DateTime(2025, 11, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1262), true, "Giảm giá 20%", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1262) },
                    { new Guid("e09e7987-2261-4e15-9926-25f00d57d38f"), "PROMO10", "Giảm giá 10% cho tất cả các sản phẩm trong dịp lễ.", 10m, new DateTime(2025, 11, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1255), true, "Giảm giá 10%", new DateTime(2025, 10, 15, 5, 10, 0, 971, DateTimeKind.Utc).AddTicks(1254) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("87c7df5b-eb5e-41c2-8843-d1313ef246d2"), new DateTime(2025, 10, 15, 5, 10, 0, 970, DateTimeKind.Utc).AddTicks(3007), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$uUHKx.dEE6Vze.esnUaEk.9XB5MYzG4X1lwsm/EUP8ErCQjRL33e.", "0123456789", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionProducts_PromotionId",
                table: "PromotionProducts",
                column: "PromotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
