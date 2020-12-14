using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "30176d82-1923-4ecb-81cf-919cd4dec263", 0, "f64ccdc0-f984-46bd-af21-8dcfe98e9629", "frankofoedu@yahoo.com", true, false, null, null, null, "AQAAAAEAACcQAAAAED4id1IHiF8u7M4axm8V3YojlAoqoH/meU1t3C3nX0UItAtnIutcPeHK4iuZWJ512A==", null, false, "1f5bdf72-96a7-4ce8-8bcc-f3f1d85c37a7", false, "frankofoedu@yahoo.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30176d82-1923-4ecb-81cf-919cd4dec263");
        }
    }
}
