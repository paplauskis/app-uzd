using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_manager_manager_id",
                table: "community");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_community_community_id",
                table: "manager");

            migrationBuilder.AlterColumn<int>(
                name: "community_id",
                table: "manager",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "manager_id",
                table: "community",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_community_manager_manager_id",
                table: "community",
                column: "manager_id",
                principalTable: "manager",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_manager_community_community_id",
                table: "manager",
                column: "community_id",
                principalTable: "community",
                principalColumn: "id");
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

            migrationBuilder.AlterColumn<int>(
                name: "community_id",
                table: "manager",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "manager_id",
                table: "community",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
