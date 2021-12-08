using Microsoft.EntityFrameworkCore.Migrations;

namespace BurgerFnatics.Data.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuGroupID",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuGroup_MenuID",
                table: "MenuGroup");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuGroupID",
                table: "MenuItem",
                column: "MenuGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroup_MenuID",
                table: "MenuGroup",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuGroupID",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuGroup_MenuID",
                table: "MenuGroup");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuGroupID",
                table: "MenuItem",
                column: "MenuGroupID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem",
                column: "MenuID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroup_MenuID",
                table: "MenuGroup",
                column: "MenuID",
                unique: true);
        }
    }
}
