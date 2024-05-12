using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUserInfoProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    UserInfoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.UserInfoUid);
                    table.ForeignKey(
                        name: "FK_Credentials_UserInfos_UserInfoUid",
                        column: x => x.UserInfoUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonProfessionalInterest",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProfessionalInterest", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "StudyField",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyField", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "NonProfessionalInterestUserInfo",
                columns: table => new
                {
                    NonProfessionalInterestsUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProfessionalInterestUserInfo", x => new { x.NonProfessionalInterestsUid, x.UsersUid });
                    table.ForeignKey(
                        name: "FK_NonProfessionalInterestUserInfo_NonProfessionalInterest_NonProfessionalInterestsUid",
                        column: x => x.NonProfessionalInterestsUid,
                        principalTable: "NonProfessionalInterest",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonProfessionalInterestUserInfo_UserInfos_UsersUid",
                        column: x => x.UsersUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillUserInfo",
                columns: table => new
                {
                    SkillsUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUserInfo", x => new { x.SkillsUid, x.UsersUid });
                    table.ForeignKey(
                        name: "FK_SkillUserInfo_Skill_SkillsUid",
                        column: x => x.SkillsUid,
                        principalTable: "Skill",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUserInfo_UserInfos_UsersUid",
                        column: x => x.UsersUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyFieldUserInfo",
                columns: table => new
                {
                    StudyFieldsUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyFieldUserInfo", x => new { x.StudyFieldsUid, x.UsersUid });
                    table.ForeignKey(
                        name: "FK_StudyFieldUserInfo_StudyField_StudyFieldsUid",
                        column: x => x.StudyFieldsUid,
                        principalTable: "StudyField",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyFieldUserInfo_UserInfos_UsersUid",
                        column: x => x.UsersUid,
                        principalTable: "UserInfos",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NonProfessionalInterestUserInfo_UsersUid",
                table: "NonProfessionalInterestUserInfo",
                column: "UsersUid");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUserInfo_UsersUid",
                table: "SkillUserInfo",
                column: "UsersUid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyFieldUserInfo_UsersUid",
                table: "StudyFieldUserInfo",
                column: "UsersUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "NonProfessionalInterestUserInfo");

            migrationBuilder.DropTable(
                name: "SkillUserInfo");

            migrationBuilder.DropTable(
                name: "StudyFieldUserInfo");

            migrationBuilder.DropTable(
                name: "NonProfessionalInterest");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "StudyField");
        }
    }
}
