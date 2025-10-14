using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace promotion_net.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("75b46b0d-543b-42fe-bd01-75c1519af1b7"), "P002", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6050), "Điện thoại Samsung Galaxy S24 Ultra với camera chất lượng cao.", true, "Samsung Galaxy S24 Ultra", 900000m, new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6048) },
                    { new Guid("c8801b15-2171-4d74-b739-2168499c3eee"), "P003", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6099), "Điện thoại Google Pixel 8 Pro với trải nghiệm Android thuần túy.", true, "Google Pixel 8 Pro", 800000m, new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6093) },
                    { new Guid("ca732122-4d34-40ed-a4f3-eb75c42c4063"), "P001", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6047), "Điện thoại iPhone 16 Pro mới nhất với nhiều tính năng vượt trội.", true, "iPhone 16 Pro", 1000000m, new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6013) }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "Description", "DiscountPercent", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("84883ffa-1cf9-483d-8b29-d67bf2b4b135"), "PROMO20", "Giảm giá 20% cho các sản phẩm điện thoại cao cấp.", 20m, new DateTime(2025, 11, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6143), true, "Giảm giá 20%", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6143) },
                    { new Guid("b298801f-0bc0-46c4-8c95-56920bb074d1"), "PROMO10", "Giảm giá 10% cho tất cả các sản phẩm trong dịp lễ.", 10m, new DateTime(2025, 11, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6135), true, "Giảm giá 10%", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6134) },
                    { new Guid("f1066cb7-1a63-4629-b1ae-4a83f89f87a1"), "WELCOME15", "Chào mừng bạn mới đến với cửa hàng, giảm giá 15% cho đơn hàng đầu tiên.", 15m, new DateTime(2025, 11, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6146), true, "Giảm giá 15%", new DateTime(2025, 10, 14, 9, 44, 17, 147, DateTimeKind.Utc).AddTicks(6146) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("c78fbd51-276b-4020-ab46-e3264bad1850"), new DateTime(2025, 10, 14, 9, 44, 17, 146, DateTimeKind.Utc).AddTicks(8859), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$Qw8SmJuc8VPnN4MBQvLBz.8kEOb6USPk1QOeohCNVBChtRxtUHmum", "0123456789", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75b46b0d-543b-42fe-bd01-75c1519af1b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8801b15-2171-4d74-b739-2168499c3eee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca732122-4d34-40ed-a4f3-eb75c42c4063"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("84883ffa-1cf9-483d-8b29-d67bf2b4b135"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("b298801f-0bc0-46c4-8c95-56920bb074d1"));

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: new Guid("f1066cb7-1a63-4629-b1ae-4a83f89f87a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c78fbd51-276b-4020-ab46-e3264bad1850"));

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
    }
}
