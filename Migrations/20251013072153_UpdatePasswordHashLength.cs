using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace promotion_net.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordHashLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("cf81048f-77db-4b7a-8420-944125596b8f"), new DateTime(2025, 10, 13, 7, 21, 52, 798, DateTimeKind.Utc).AddTicks(2263), "nguyenhiengiabao12@gmail.com", "Nguyen Hien Gia Bao", true, null, "$2a$11$ZGkAGgEz19OGhS0dkV0CfOLbGCuqiBNhhr/sNrNpBYnQLHZADtpUm", "0123456789", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf81048f-77db-4b7a-8420-944125596b8f"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
