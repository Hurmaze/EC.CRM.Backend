using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurentSalary = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: false),
                    RoleUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_UserInfos_Roles_RoleUid",
                        column: x => x.RoleUid,
                        principalTable: "Roles",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserInfoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Jobs_UserInfos_UserInfoUid",
                        column: x => x.UserInfoUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserInfoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Mentors_UserInfos_UserInfoUid",
                        column: x => x.UserInfoUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserInfoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MentorUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Students_Mentors_MentorUid",
                        column: x => x.MentorUid,
                        principalTable: "Mentors",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Students_States_StateUid",
                        column: x => x.StateUid,
                        principalTable: "States",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_UserInfos_UserInfoUid",
                        column: x => x.UserInfoUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserInfoUid",
                table: "Jobs",
                column: "UserInfoUid");

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_UserInfoUid",
                table: "Mentors",
                column: "UserInfoUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_MentorUid",
                table: "Students",
                column: "MentorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StateUid",
                table: "Students",
                column: "StateUid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserInfoUid",
                table: "Students",
                column: "UserInfoUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_LocationUid",
                table: "UserInfos",
                column: "LocationUid");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_RoleUid",
                table: "UserInfos",
                column: "RoleUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
