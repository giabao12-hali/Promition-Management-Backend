using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace promotion_net.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4c34c5f-eb1c-4541-8207-77d94d50f709"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c8e179d-b338-4e45-b653-75cab476d9cd"), "P001", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(407), "Điện thoại iPhone 16 Pro mới nhất với nhiều tính năng vượt trội.", true, "iPhone 16 Pro", 100.00m, new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(373) },
                    { new Guid("576bf573-1228-48cb-8fda-635afe73721e"), "P003", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(425), "Điện thoại Google Pixel 8 Pro với trải nghiệm Android thuần túy.", true, "Google Pixel 8 Pro", 80.00m, new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(412) },
                    { new Guid("9707a95d-d9a2-4a35-b3cf-4c3c61ff6049"), "P002", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(411), "Điện thoại Samsung Galaxy S24 Ultra với camera chất lượng cao.", true, "Samsung Galaxy S24 Ultra", 90.00m, new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(408) }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "Description", "DiscountPercent", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("02c4575c-55eb-4fa0-9ab7-bce1db7b9d17"), "WELCOME15", "Chào mừng bạn mới đến với cửa hàng, giảm giá 15% cho đơn hàng đầu tiên.", 15m, new DateTime(2025, 11, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(496), true, "Giảm giá 15%", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(496) },
                    { new Guid("2a13c33f-3423-4308-aebc-246f5e3c731a"), "PROMO20", "Giảm giá 20% cho các sản phẩm điện thoại cao cấp.", 20m, new DateTime(2025, 11, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(493), true, "Giảm giá 20%", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(492) },
                    { new Guid("c0e7e430-1487-4e5e-a5a8-c62f9d019e65"), "PROMO10", "Giảm giá 10% cho tất cả các sản phẩm trong dịp lễ.", 10m, new DateTime(2025, 11, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(470), true, "Giảm giá 10%", new DateTime(2025, 10, 14, 9, 24, 50, 338, DateTimeKind.Utc).AddTicks(470) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("69f4bb8c-b971-414e-aee6-4e23a174d456"), new DateTime(2025, 10, 14, 9, 24, 50, 336, DateTimeKind.Utc).AddTicks(5455), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$mTxeE3o2LfOux54IHDzx0eafJLXDrcHYXDI80z23TZd1Umf6qyCtS", "0123456789", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c8e179d-b338-4e45-b653-75cab476d9cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("576bf573-1228-48cb-8fda-635afe73721e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9707a95d-d9a2-4a35-b3cf-4c3c61ff6049"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("02c4575c-55eb-4fa0-9ab7-bce1db7b9d17"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("2a13c33f-3423-4308-aebc-246f5e3c731a"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("c0e7e430-1487-4e5e-a5a8-c62f9d019e65"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69f4bb8c-b971-414e-aee6-4e23a174d456"));

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("b4c34c5f-eb1c-4541-8207-77d94d50f709"), new DateTime(2025, 10, 14, 8, 32, 21, 68, DateTimeKind.Utc).AddTicks(5368), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$Ij1sAKGc7etaE0l6W6c.yOZM5MuiULINNt9zLmPhTa7H4lzmF6VEC", "0123456789", 0 });
        }
    }
}
