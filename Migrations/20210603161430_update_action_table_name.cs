using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL3.Migrations
{
    public partial class update_action_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actions_Accounts_accountID",
                table: "actions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actions",
                table: "actions");

            migrationBuilder.RenameTable(
                name: "actions",
                newName: "Actions");

            migrationBuilder.RenameIndex(
                name: "IX_actions_accountID",
                table: "Actions",
                newName: "IX_Actions_accountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actions",
                table: "Actions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Accounts_accountID",
                table: "Actions",
                column: "accountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Accounts_accountID",
                table: "Actions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actions",
                table: "Actions");

            migrationBuilder.RenameTable(
                name: "Actions",
                newName: "actions");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_accountID",
                table: "actions",
                newName: "IX_actions_accountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actions",
                table: "actions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_actions_Accounts_accountID",
                table: "actions",
                column: "accountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
