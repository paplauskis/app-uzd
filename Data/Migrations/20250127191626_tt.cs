using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityManager");

            migrationBuilder.DropTable(
                name: "ManagerService");

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "manager",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "community",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_manager_CommunityId",
                table: "manager",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_community_ManagerId",
                table: "community",
                column: "ManagerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_manager_ManagerId",
                table: "community");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_community_CommunityId",
                table: "manager");

            migrationBuilder.DropIndex(
                name: "IX_manager_CommunityId",
                table: "manager");

            migrationBuilder.DropIndex(
                name: "IX_community_ManagerId",
                table: "community");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "manager");

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

            migrationBuilder.CreateTable(
                name: "ManagerService",
                columns: table => new
                {
                    ManagersId = table.Column<int>(type: "integer", nullable: false),
                    ServicesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerService", x => new { x.ManagersId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ManagerService_manager_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "manager",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerService_service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityManager_ManagersId",
                table: "CommunityManager",
                column: "ManagersId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerService_ServicesId",
                table: "ManagerService",
                column: "ServicesId");
        }
    }
}
