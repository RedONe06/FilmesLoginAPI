using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Login.Migrations
{
    public partial class Roledeadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99999, "4188b2df-3712-4c56-b240-c8f3750dad47", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 99999, 0, "dd6146f3-cd5b-4043-9923-ca09e22d43d6", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFl3zYRLc18SaD2aoLXhWkdiWzQlOxuafbbXXq8M5QYN53sKIKt1IOrJlMxHYTtKRA==", null, false, "412cd6bc-e47f-4b3a-b904-e58e2a3271f2", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 99999, 99999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 99999, 99999 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999);
        }
    }
}
