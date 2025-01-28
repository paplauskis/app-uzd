using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerService");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "service_type",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "manager",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_type_ManagerId",
                table: "service_type",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_manager_ServiceId",
                table: "manager",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_manager_service_ServiceId",
                table: "manager",
                column: "ServiceId",
                principalTable: "service",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_type_manager_ManagerId",
                table: "service_type",
                column: "ManagerId",
                principalTable: "manager",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_manager_service_ServiceId",
                table: "manager");

            migrationBuilder.DropForeignKey(
                name: "FK_service_type_manager_ManagerId",
                table: "service_type");

            migrationBuilder.DropIndex(
                name: "IX_service_type_ManagerId",
                table: "service_type");

            migrationBuilder.DropIndex(
                name: "IX_manager_ServiceId",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "service_type");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "manager");

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
                name: "IX_ManagerService_ServicesId",
                table: "ManagerService",
                column: "ServicesId");
        }
    }
}
