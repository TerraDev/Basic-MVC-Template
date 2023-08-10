using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCtest.Infrastructure.Migrations
{
    public partial class AppUserIdentityAutoGen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "47c831a3-132b-46a9-b049-fce534599bde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "494fa87a-10c5-406d-9200-8bd8eb8f4879");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "978fd1ae-4dbf-44c2-8c57-5eb5d5f846df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62d74731-4502-4677-991b-6793526390c7", "93aec265-73c8-4178-b8be-2f070335dfac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "9df5104d-495d-4bd3-a8dd-5107732516b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "931e1661-5f86-40de-98d5-88fc09a97f03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "d9faf91e-588b-4e17-b02b-c02baff5be15");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e41e815f-4b39-4736-8ecd-9112224e231c", "90d4b5f6-bd20-4783-9983-f7acd83a775c" });
        }
    }
}
