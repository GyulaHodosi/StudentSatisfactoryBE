using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class Reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(nullable: false),
                    FillCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AverageOfAnswers",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Average = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AverageOfAnswers", x => new { x.ReportId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_AverageOfAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AverageOfAnswers_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AverageOfAnswers_QuestionId",
                table: "AverageOfAnswers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageOfAnswers");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
