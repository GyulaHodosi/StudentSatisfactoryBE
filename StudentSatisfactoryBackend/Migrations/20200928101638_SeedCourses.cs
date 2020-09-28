using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class SeedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "progbasics@code.cool", "Fullstack - Programming Basics" },
                    { 2, "web@code.cool", "Fullstack - Web" },
                    { 3, "oop@code.cool", "Fullstack - OOP" },
                    { 4, "advanced@code.cool", "Fullstack - Advanced" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
