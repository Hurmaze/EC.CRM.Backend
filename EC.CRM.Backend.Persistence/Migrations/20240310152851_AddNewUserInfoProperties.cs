using System;
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
            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bf7f6023-f109-4782-b8c2-6ff67571a539"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("73f8447e-8b35-4f32-adac-9fe9876529cf"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ee97f425-d79e-416b-a6ee-0233dff83129"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("14f705dc-a2af-437e-88a2-c6b6a90c1d2a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f07ab32b-419f-4e3e-b1ff-58fa7b49932b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("940c8245-661d-4d10-b948-a5edbe18dee4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("330328e9-3bed-4110-9f03-124397340471"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6fce367f-9c02-4b7e-9604-6f0004afd83f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("78f720ca-9212-470c-87ae-f9acef45c523"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9132b8a0-071c-467f-a146-becf9256dde4"));

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

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("73f8447e-8b35-4f32-adac-9fe9876529cf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bf7f6023-f109-4782-b8c2-6ff67571a539"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("14f705dc-a2af-437e-88a2-c6b6a90c1d2a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ee97f425-d79e-416b-a6ee-0233dff83129"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("940c8245-661d-4d10-b948-a5edbe18dee4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f07ab32b-419f-4e3e-b1ff-58fa7b49932b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6fce367f-9c02-4b7e-9604-6f0004afd83f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("330328e9-3bed-4110-9f03-124397340471"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9132b8a0-071c-467f-a146-becf9256dde4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("78f720ca-9212-470c-87ae-f9acef45c523"));
        }
    }
}
