using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class VoteCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVote",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FeedbackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVote", x => new { x.UserId, x.FeedbackId });
                    table.ForeignKey(
                        name: "FK_UserVote_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2020, 10, 1, 14, 8, 37, 696, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_FeedbackId",
                table: "UserVote",
                column: "FeedbackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVote");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4617));
        }
    }
}
