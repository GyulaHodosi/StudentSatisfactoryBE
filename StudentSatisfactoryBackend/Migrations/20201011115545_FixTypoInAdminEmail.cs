using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class FixTypoInAdminEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminEmails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "codecool.satisfactionapp@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminEmails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "codecool.satisafactionapp@gmail.com");
        }
    }
}
