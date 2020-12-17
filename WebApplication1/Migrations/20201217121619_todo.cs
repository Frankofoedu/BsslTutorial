using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30176d82-1923-4ecb-81cf-919cd4dec263");

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "095f2e70-22b9-4a9d-aa12-70f3c11ea2d9", 0, "114be19e-af31-4a16-8156-44da19c036a3", "frankofoedu@yahoo.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEDPbMM7PJPX8dzcQwD1dty8jl/LAodPrikMMalHxYg+VbO412+u+HH3BqHlFwErmRQ==", null, false, "e95fd321-993f-45b6-852f-94aa62a83613", false, "frankofoedu@yahoo.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "095f2e70-22b9-4a9d-aa12-70f3c11ea2d9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "30176d82-1923-4ecb-81cf-919cd4dec263", 0, "f64ccdc0-f984-46bd-af21-8dcfe98e9629", "frankofoedu@yahoo.com", true, false, null, null, null, "AQAAAAEAACcQAAAAED4id1IHiF8u7M4axm8V3YojlAoqoH/meU1t3C3nX0UItAtnIutcPeHK4iuZWJ512A==", null, false, "1f5bdf72-96a7-4ce8-8bcc-f3f1d85c37a7", false, "frankofoedu@yahoo.com" });
        }
    }
}
