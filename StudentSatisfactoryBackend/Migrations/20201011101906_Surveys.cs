using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class Surveys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserQuestions");

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "UserQuestions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "UserQuestions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserQuestions",
                type: "nvarchar(max)",
                nullable: true);

            
        }
    }
}
