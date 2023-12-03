using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Bookstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d238f30e-9ae4-410e-bf96-9bba15d0b9f6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60551cce-d726-4ace-8295-2b5a8b4fad52", 0, "53172431-ca92-4e90-b2c2-b0318a41a27d", null, false, "Diyorbek", false, null, null, null, "522e895f759c27cce490109a6409b865019236632164c13559fe9872244f1138", null, "+998942922288", false, "ce480484-8297-4baa-b3f4-4e9eb5cc53b1", false, "DiyorbekOdilov" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60551cce-d726-4ace-8295-2b5a8b4fad52");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d238f30e-9ae4-410e-bf96-9bba15d0b9f6", 0, "3a9ef380-7d19-40bd-b881-4077a70b89be", null, false, "Diyorbek", false, null, null, null, "522e895f759c27cce490109a6409b865019236632164c13559fe9872244f1138", null, "+998942922288", false, "55b59f0e-9e01-4522-a402-7dde4189b90b", false, "DiyorbekOdilov" });
        }
    }
}
