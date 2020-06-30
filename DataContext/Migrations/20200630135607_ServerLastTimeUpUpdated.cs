using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class ServerLastTimeUpUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeUp",
                table: "Servers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "1",
                column: "LastTimeUp",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "2",
                column: "LastTimeUp",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "3",
                column: "LastTimeUp",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "4",
                column: "LastTimeUp",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeUp",
                table: "Servers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "1",
                column: "LastTimeUp",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "2",
                column: "LastTimeUp",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "3",
                column: "LastTimeUp",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: "4",
                column: "LastTimeUp",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
