using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class RoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6e655a4-518e-4e06-8755-4c25fb027a05", "10b78298-8b6f-4f93-8f90-8805ba08a6a4", "warehouse", "warehouse" },
                    { "b33df268-1ee3-4798-9966-44018f0fcdbf", "e357a305-375b-43a5-ad5e-ab79dc6173c9", "admin", "admin" },
                    { "aae3f34b-96ca-4a0b-9362-3a70f231ff0f", "79c4dcbd-f350-4bd5-af32-6701950171d0", "user", "user" },
                    { "71fbb7ac-4e90-4af2-8bfa-7b8781c52a3e", "a5098b90-9e79-4cb5-b438-711b795cd4e7", "department", "department" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6e655a4-518e-4e06-8755-4c25fb027a05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b33df268-1ee3-4798-9966-44018f0fcdbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aae3f34b-96ca-4a0b-9362-3a70f231ff0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71fbb7ac-4e90-4af2-8bfa-7b8781c52a3e");
        }
    }
}
