using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL3.Migrations
{
    public partial class update_account_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avar",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 1,
                column: "timeCreate",
                value: new DateTime(2021, 6, 13, 14, 53, 19, 359, DateTimeKind.Local).AddTicks(2247));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avar",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 1,
                column: "timeCreate",
                value: new DateTime(2021, 6, 10, 21, 25, 36, 7, DateTimeKind.Local).AddTicks(7300));
        }
    }
}
