using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace promotion_net.Migrations
{
    /// <inheritdoc />
    public partial class InitProductPromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf81048f-77db-4b7a-8420-944125596b8f"));

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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("b4c34c5f-eb1c-4541-8207-77d94d50f709"), new DateTime(2025, 10, 14, 8, 32, 21, 68, DateTimeKind.Utc).AddTicks(5368), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$Ij1sAKGc7etaE0l6W6c.yOZM5MuiULINNt9zLmPhTa7H4lzmF6VEC", "0123456789", 0 });

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4c34c5f-eb1c-4541-8207-77d94d50f709"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("cf81048f-77db-4b7a-8420-944125596b8f"), new DateTime(2025, 10, 13, 7, 21, 52, 798, DateTimeKind.Utc).AddTicks(2263), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$ZGkAGgEz19OGhS0dkV0CfOLbGCuqiBNhhr/sNrNpBYnQLHZADtpUm", "0123456789", 0 });
        }
    }
}
