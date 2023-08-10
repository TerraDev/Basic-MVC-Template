using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCtest.Infrastructure.Migrations
{
    public partial class SuperAdminPassHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15337A34-8592-4417-8C9E-ACF960B00102",
                column: "ConcurrencyStamp",
                value: "e6425bc0-e577-4ebb-8159-23267dfccbdd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29D9873B-8339-4E70-8DE4-544507529A74",
                column: "ConcurrencyStamp",
                value: "3dd64a50-c3d8-4ba7-bdcf-c2dc88ca3709");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D0074DD6-E540-45D4-A804-5E1A42C81661",
                column: "ConcurrencyStamp",
                value: "587f3cf9-8630-411d-a0f3-184f494d2435");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B37C0271-DDD7-4124-AD52-69360F5A219F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c52c6c6b-9e30-4a2b-8baa-addda529353a", "AQAAAAEAACcQAAAAEFZnxuAQPx8Qa2Wshihw6NzkOfUQoMdQZ5ps6d85809IlfuWqkmwcp7UkcMY2ZIakg==", "65299567-5ce7-4ccc-97d1-eaff7c48db77" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62d74731-4502-4677-991b-6793526390c7", null, "93aec265-73c8-4178-b8be-2f070335dfac" });
        }
    }
}
