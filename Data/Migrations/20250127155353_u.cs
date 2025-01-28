using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class u : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_type_service_service_id",
                table: "service_type");

            migrationBuilder.DropIndex(
                name: "IX_service_type_service_id",
                table: "service_type");

            migrationBuilder.DropColumn(
                name: "service_id",
                table: "service_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "service_id",
                table: "service_type",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_service_type_service_id",
                table: "service_type",
                column: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_type_service_service_id",
                table: "service_type",
                column: "service_id",
                principalTable: "service",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
