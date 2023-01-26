using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_Title",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 26, 8, 41, 57, 746, DateTimeKind.Utc).AddTicks(3222), new DateTime(2023, 1, 26, 11, 41, 57, 746, DateTimeKind.Local).AddTicks(3152) });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Title_UserId",
                table: "Task",
                columns: new[] { "Title", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_Title_UserId",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 25, 20, 38, 13, 628, DateTimeKind.Utc).AddTicks(7100), new DateTime(2023, 1, 25, 23, 38, 13, 628, DateTimeKind.Local).AddTicks(7019) });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Title",
                table: "Task",
                column: "Title",
                unique: true);
        }
    }
}
