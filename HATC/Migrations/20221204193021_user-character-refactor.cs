using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HATC.Migrations
{
    public partial class usercharacterrefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sessions_SessionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SessionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Characters_UserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "PlayerUserId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerUserId",
                table: "Characters",
                column: "PlayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SessionId",
                table: "Characters",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_PlayerUserId",
                table: "Characters",
                column: "PlayerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_PlayerUserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlayerUserId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SessionId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PlayerUserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SessionId",
                table: "Users",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sessions_SessionId",
                table: "Users",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
