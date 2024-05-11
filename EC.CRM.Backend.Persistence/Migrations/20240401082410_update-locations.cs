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
        }
    }
}
