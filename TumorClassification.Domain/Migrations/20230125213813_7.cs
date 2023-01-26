using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Task_UserId",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 25, 20, 38, 13, 628, DateTimeKind.Utc).AddTicks(7100), new DateTime(2023, 1, 25, 23, 38, 13, 628, DateTimeKind.Local).AddTicks(7019) });

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_UserId",
                table: "Task");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Task_UserId",
                table: "Task",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 25, 22, 9, 6, 33, DateTimeKind.Utc).AddTicks(2110), new DateTime(2023, 1, 25, 23, 9, 6, 33, DateTimeKind.Local).AddTicks(2032) });
        }
    }
}
