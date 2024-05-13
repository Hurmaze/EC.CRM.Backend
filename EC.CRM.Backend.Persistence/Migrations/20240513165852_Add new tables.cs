using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addnewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonProfessionalInterestUserInfo_NonProfessionalInterest_NonProfessionalInterestsUid",
                table: "NonProfessionalInterestUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUserInfo_Skill_SkillsUid",
                table: "SkillUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyFieldUserInfo_StudyField_StudyFieldsUid",
                table: "StudyFieldUserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyField",
                table: "StudyField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonProfessionalInterest",
                table: "NonProfessionalInterest");

            migrationBuilder.RenameTable(
                name: "StudyField",
                newName: "StudyFields");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "NonProfessionalInterest",
                newName: "NonProfessionalInterests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyFields",
                table: "StudyFields",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonProfessionalInterests",
                table: "NonProfessionalInterests",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_NonProfessionalInterestUserInfo_NonProfessionalInterests_NonProfessionalInterestsUid",
                table: "NonProfessionalInterestUserInfo",
                column: "NonProfessionalInterestsUid",
                principalTable: "NonProfessionalInterests",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUserInfo_Skills_SkillsUid",
                table: "SkillUserInfo",
                column: "SkillsUid",
                principalTable: "Skills",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyFieldUserInfo_StudyFields_StudyFieldsUid",
                table: "StudyFieldUserInfo",
                column: "StudyFieldsUid",
                principalTable: "StudyFields",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonProfessionalInterestUserInfo_NonProfessionalInterests_NonProfessionalInterestsUid",
                table: "NonProfessionalInterestUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUserInfo_Skills_SkillsUid",
                table: "SkillUserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyFieldUserInfo_StudyFields_StudyFieldsUid",
                table: "StudyFieldUserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyFields",
                table: "StudyFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonProfessionalInterests",
                table: "NonProfessionalInterests");

            migrationBuilder.RenameTable(
                name: "StudyFields",
                newName: "StudyField");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "NonProfessionalInterests",
                newName: "NonProfessionalInterest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyField",
                table: "StudyField",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonProfessionalInterest",
                table: "NonProfessionalInterest",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_NonProfessionalInterestUserInfo_NonProfessionalInterest_NonProfessionalInterestsUid",
                table: "NonProfessionalInterestUserInfo",
                column: "NonProfessionalInterestsUid",
                principalTable: "NonProfessionalInterest",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUserInfo_Skill_SkillsUid",
                table: "SkillUserInfo",
                column: "SkillsUid",
                principalTable: "Skill",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyFieldUserInfo_StudyField_StudyFieldsUid",
                table: "StudyFieldUserInfo",
                column: "StudyFieldsUid",
                principalTable: "StudyField",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
