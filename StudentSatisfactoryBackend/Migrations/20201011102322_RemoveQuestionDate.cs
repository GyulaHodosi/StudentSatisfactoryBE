using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class RemoveQuestionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 835, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2020, 10, 11, 12, 19, 5, 838, DateTimeKind.Local).AddTicks(1534));
        }
    }
}
