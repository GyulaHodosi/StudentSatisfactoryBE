using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSatisfactoryBackend.Migrations
{
    public partial class UserVotesdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Feedbacks_FeedbackId",
                table: "UserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_AspNetUsers_UserId",
                table: "UserVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote");

            migrationBuilder.RenameTable(
                name: "UserVote",
                newName: "UserVotes");

            migrationBuilder.RenameIndex(
                name: "IX_UserVote_FeedbackId",
                table: "UserVotes",
                newName: "IX_UserVotes_FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes",
                columns: new[] { "UserId", "FeedbackId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_Feedbacks_FeedbackId",
                table: "UserVotes",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_AspNetUsers_UserId",
                table: "UserVotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_Feedbacks_FeedbackId",
                table: "UserVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_AspNetUsers_UserId",
                table: "UserVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes");

            migrationBuilder.RenameTable(
                name: "UserVotes",
                newName: "UserVote");

            migrationBuilder.RenameIndex(
                name: "IX_UserVotes_FeedbackId",
                table: "UserVote",
                newName: "IX_UserVote_FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote",
                columns: new[] { "UserId", "FeedbackId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Feedbacks_FeedbackId",
                table: "UserVote",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_AspNetUsers_UserId",
                table: "UserVote",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
