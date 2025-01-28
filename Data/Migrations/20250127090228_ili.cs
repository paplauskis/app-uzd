using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ili : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_ServiceType_service_type_id",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceType_service_service_id",
                table: "ServiceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType");

            migrationBuilder.RenameTable(
                name: "ServiceType",
                newName: "service_type");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceType_service_id",
                table: "service_type",
                newName: "IX_service_type_service_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_type",
                table: "service_type",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_service_type_service_type_id",
                table: "service",
                column: "service_type_id",
                principalTable: "service_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_type_service_service_id",
                table: "service_type",
                column: "service_id",
                principalTable: "service",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_service_type_service_type_id",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FK_service_type_service_service_id",
                table: "service_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_type",
                table: "service_type");

            migrationBuilder.RenameTable(
                name: "service_type",
                newName: "ServiceType");

            migrationBuilder.RenameIndex(
                name: "IX_service_type_service_id",
                table: "ServiceType",
                newName: "IX_ServiceType_service_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_ServiceType_service_type_id",
                table: "service",
                column: "service_type_id",
                principalTable: "ServiceType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceType_service_service_id",
                table: "ServiceType",
                column: "service_id",
                principalTable: "service",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
