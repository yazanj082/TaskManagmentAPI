using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 25, 21, 56, 28, 946, DateTimeKind.Utc).AddTicks(7089), new DateTime(2023, 1, 25, 22, 56, 28, 946, DateTimeKind.Local).AddTicks(7014) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 25, 21, 53, 50, 256, DateTimeKind.Utc).AddTicks(7131), new DateTime(2023, 1, 25, 22, 53, 50, 256, DateTimeKind.Local).AddTicks(7055) });
        }
    }
}
