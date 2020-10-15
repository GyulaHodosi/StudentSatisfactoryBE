using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class SeedQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Date", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4363), "Codecool office staff has good response times when there's a question or problem" },
                    { 19, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4604), "What do you think about the amount of teamwork in Codecool?" },
                    { 18, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4597), "What do you think about the number of frontal lessons in Codecool?" },
                    { 17, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4589), "Codecool's job interview preparation is a huge help for me to get a job I need." },
                    { 16, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4582), "I believe that there are enough positions to choose from after graduating from Codecool." },
                    { 15, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4576), "I would definitely need Codecool's help in finding my first job after graduating." },
                    { 14, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4569), "I believe that I will find a job suitable for me after graduating from Codecool." },
                    { 13, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4562), "I get enough emotional support (either from my peers or from staff members) when I need to." },
                    { 12, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4556), "I get enough professional help(either from my peers or from staff members) in order to improve in soft skills." },
                    { 20, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4611), "What do you think about the amount of self-study time in Codecool?" },
                    { 11, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4549), "I get enough professional help (either from my peers or from mentors) in order to improve in hard skills." },
                    { 9, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4534), "The practical materials provided by Codecool help my journey becoming a junior developer." },
                    { 8, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4527), "The theoretical materials provided by Codecool help my journey becoming a junior developer." },
                    { 7, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4520), "Codecool office offers a clean and calm environment that is needed for me to focus on my studies." },
                    { 6, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4514), "Codecool is located in a great place (easily reachable, travel time from your home is okay)." },
                    { 5, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4503), "I feel belonging to a group in Codecool and it satisfies me." },
                    { 4, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4496), "There's a cool atmosphere in Codecool which helps me to improve and stay motivated." },
                    { 3, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4489), "The process of study/job contracting, signing paperwork is smooth, communication about it is satisfactory." },
                    { 2, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4482), "There's a valid reaction (something happens) from Codecool office staff when I raise a problem." },
                    { 10, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4542), "The requirements or competencies in the curriculum provided by Codecool are clear and help my journey becoming a software developer." },
                    { 21, new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4617), "What do you think about the number of interactive workshops in Codecool?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
