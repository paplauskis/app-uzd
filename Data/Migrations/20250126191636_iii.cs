using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class iii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_manager_ManagerId",
                table: "community");

            migrationBuilder.DropIndex(
                name: "IX_community_ManagerId",
                table: "community");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "community");

            migrationBuilder.CreateTable(
                name: "CommunityManager",
                columns: table => new
                {
                    CommunitiesId = table.Column<int>(type: "integer", nullable: false),
                    ManagersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityManager", x => new { x.CommunitiesId, x.ManagersId });
                    table.ForeignKey(
                        name: "FK_CommunityManager_community_CommunitiesId",
                        column: x => x.CommunitiesId,
                        principalTable: "community",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityManager_manager_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "manager",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityManager_ManagersId",
                table: "CommunityManager",
                column: "ManagersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityManager");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "community",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_community_ManagerId",
                table: "community",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_community_manager_ManagerId",
                table: "community",
                column: "ManagerId",
                principalTable: "manager",
                principalColumn: "id");
        }
    }
}
