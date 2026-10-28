using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepititionMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateFound",
                table: "Case",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFound",
                value: new DateOnly(2026, 10, 1));

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateFound",
                value: new DateOnly(2013, 11, 5));

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateFound",
                value: new DateOnly(2004, 9, 12));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFound",
                table: "Case",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFound",
                value: new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateFound",
                value: new DateTime(2013, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Case",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateFound",
                value: new DateTime(2004, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
