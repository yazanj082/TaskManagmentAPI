using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_UserId",
                table: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Task",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Task_UserId",
                table: "Task",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "123456", "yazan" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "EndDate", "StartDate", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2023, 1, 24, 22, 5, 22, 982, DateTimeKind.Utc).AddTicks(2317), new DateTime(2023, 1, 24, 23, 5, 22, 982, DateTimeKind.Local).AddTicks(2241), "Study", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Title",
                table: "Task",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Task_UserId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_Title",
                table: "Task");

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");
        }
    }
}
