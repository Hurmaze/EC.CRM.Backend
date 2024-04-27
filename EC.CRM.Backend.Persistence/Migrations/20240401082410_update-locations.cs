using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatelocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Locations_LocationUid",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_LocationUid",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "LocationUid",
                table: "UserInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8c1069ef-cc09-42ba-b13f-f0e57a144e38"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bf7f6023-f109-4782-b8c2-6ff67571a539"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d32bd883-7889-41aa-98fc-797045b3c4c6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ee97f425-d79e-416b-a6ee-0233dff83129"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f87a9f76-708c-4c23-aff4-0ea5578b3bd4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f07ab32b-419f-4e3e-b1ff-58fa7b49932b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f850026e-f962-4a69-adfe-95271a24d246"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("330328e9-3bed-4110-9f03-124397340471"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cd5e6fe9-4844-45c0-8616-10cee274f89e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("78f720ca-9212-470c-87ae-f9acef45c523"));*/

            migrationBuilder.CreateTable(
                name: "LocationUserInfo",
                columns: table => new
                {
                    LocationsUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationUserInfo", x => new { x.LocationsUid, x.UsersUid });
                    table.ForeignKey(
                        name: "FK_LocationUserInfo_Locations_LocationsUid",
                        column: x => x.LocationsUid,
                        principalTable: "Locations",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationUserInfo_UserInfos_UsersUid",
                        column: x => x.UsersUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationUserInfo_UsersUid",
                table: "LocationUserInfo",
                column: "UsersUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationUserInfo");

            /*migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bf7f6023-f109-4782-b8c2-6ff67571a539"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8c1069ef-cc09-42ba-b13f-f0e57a144e38"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocationUid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ee97f425-d79e-416b-a6ee-0233dff83129"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d32bd883-7889-41aa-98fc-797045b3c4c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f07ab32b-419f-4e3e-b1ff-58fa7b49932b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f87a9f76-708c-4c23-aff4-0ea5578b3bd4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("330328e9-3bed-4110-9f03-124397340471"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f850026e-f962-4a69-adfe-95271a24d246"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("78f720ca-9212-470c-87ae-f9acef45c523"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cd5e6fe9-4844-45c0-8616-10cee274f89e"));

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_LocationUid",
                table: "UserInfos",
                column: "LocationUid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Locations_LocationUid",
                table: "UserInfos",
                column: "LocationUid",
                principalTable: "Locations",
                principalColumn: "Uid");*/
        }
    }
}
