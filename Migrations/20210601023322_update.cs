using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL3.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_TypeNotification_typeNotificationID",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeNotification",
                table: "TypeNotification");

            migrationBuilder.RenameTable(
                name: "TypeNotification",
                newName: "typeNotifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_typeNotifications",
                table: "typeNotifications",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_typeNotifications_typeNotificationID",
                table: "Notifications",
                column: "typeNotificationID",
                principalTable: "typeNotifications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_typeNotifications_typeNotificationID",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_typeNotifications",
                table: "typeNotifications");

            migrationBuilder.RenameTable(
                name: "typeNotifications",
                newName: "TypeNotification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeNotification",
                table: "TypeNotification",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_TypeNotification_typeNotificationID",
                table: "Notifications",
                column: "typeNotificationID",
                principalTable: "TypeNotification",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
