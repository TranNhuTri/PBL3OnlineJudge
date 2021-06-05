using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL3.Migrations
{
    public partial class add_action_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    objectID = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_actions_Accounts_accountID",
                        column: x => x.accountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actions_accountID",
                table: "actions",
                column: "accountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actions");
        }
    }
}
