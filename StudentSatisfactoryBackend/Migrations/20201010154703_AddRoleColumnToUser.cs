using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class AddRoleColumnToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEmails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminEmails",
                columns: new[] { "Id", "Email" },
                values: new object[] { 1, "codecool.satisafactionapp@gmail.com" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEmails");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

        }
    }
}
