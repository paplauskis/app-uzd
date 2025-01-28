using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_manager_ManagerId",
                table: "community");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_community_CommunityId",
                table: "manager");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "manager",
                newName: "community_id");

            migrationBuilder.RenameIndex(
                name: "IX_manager_CommunityId",
                table: "manager",
                newName: "IX_manager_community_id");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "community",
                newName: "manager_id");

            migrationBuilder.RenameIndex(
                name: "IX_community_ManagerId",
                table: "community",
                newName: "IX_community_manager_id");

            migrationBuilder.AddForeignKey(
                name: "FK_community_manager_manager_id",
                table: "community",
                column: "manager_id",
                principalTable: "manager",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_community_community_id",
                table: "manager",
                column: "community_id",
                principalTable: "community",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_manager_manager_id",
                table: "community");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_community_community_id",
                table: "manager");

            migrationBuilder.RenameColumn(
                name: "community_id",
                table: "manager",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_manager_community_id",
                table: "manager",
                newName: "IX_manager_CommunityId");

            migrationBuilder.RenameColumn(
                name: "manager_id",
                table: "community",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_community_manager_id",
                table: "community",
                newName: "IX_community_ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_community_manager_ManagerId",
                table: "community",
                column: "ManagerId",
                principalTable: "manager",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_community_CommunityId",
                table: "manager",
                column: "CommunityId",
                principalTable: "community",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
