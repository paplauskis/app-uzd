using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_community_service_ServiceId",
                table: "community");

            migrationBuilder.DropForeignKey(
                name: "FK_resident_community_CommunityId",
                table: "resident");

            migrationBuilder.DropIndex(
                name: "IX_community_ServiceId",
                table: "community");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "community");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "community");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "resident",
                newName: "community_id");

            migrationBuilder.RenameIndex(
                name: "IX_resident_CommunityId",
                table: "resident",
                newName: "IX_resident_community_id");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "community",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "community",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "community",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "community",
                newName: "house_number");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "service",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "service",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "resident",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "resident",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "manager",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "manager",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "community",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "community",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "community",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "house_number",
                table: "community",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "admin",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "admin",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "CommunityService",
                columns: table => new
                {
                    CommunitiesId = table.Column<int>(type: "integer", nullable: false),
                    ServicesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityService", x => new { x.CommunitiesId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_CommunityService_community_CommunitiesId",
                        column: x => x.CommunitiesId,
                        principalTable: "community",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityService_service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityService_ServicesId",
                table: "CommunityService",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_resident_community_community_id",
                table: "resident",
                column: "community_id",
                principalTable: "community",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resident_community_community_id",
                table: "resident");

            migrationBuilder.DropTable(
                name: "CommunityService");

            migrationBuilder.DropColumn(
                name: "price",
                table: "service");

            migrationBuilder.RenameColumn(
                name: "community_id",
                table: "resident",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_resident_community_id",
                table: "resident",
                newName: "IX_resident_CommunityId");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "community",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "community",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "community",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "house_number",
                table: "community",
                newName: "HouseNumber");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "service",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "resident",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "resident",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "manager",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "manager",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "community",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "community",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "community",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "community",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "community",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "community",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "admin",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "admin",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_community_ServiceId",
                table: "community",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_community_service_ServiceId",
                table: "community",
                column: "ServiceId",
                principalTable: "service",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_resident_community_CommunityId",
                table: "resident",
                column: "CommunityId",
                principalTable: "community",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
