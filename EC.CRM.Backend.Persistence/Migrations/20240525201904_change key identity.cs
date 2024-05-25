using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changekeyidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Mentors_Id",
                table: "MentorValuations");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Students_Id",
                table: "MentorValuations");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserInfoUid",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_UserInfoUid",
                table: "Mentors");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_UserInfoUid",
                table: "Students",
                column: "UserInfoUid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Mentors_UserInfoUid",
                table: "Mentors",
                column: "UserInfoUid");

            migrationBuilder.CreateIndex(
                name: "IX_MentorValuations_MentorUid",
                table: "MentorValuations",
                column: "MentorUid");

            migrationBuilder.CreateIndex(
                name: "IX_MentorValuations_StudentUid",
                table: "MentorValuations",
                column: "StudentUid");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Mentors_MentorUid",
                table: "MentorValuations",
                column: "MentorUid",
                principalTable: "Mentors",
                principalColumn: "UserInfoUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Students_StudentUid",
                table: "MentorValuations",
                column: "StudentUid",
                principalTable: "Students",
                principalColumn: "UserInfoUid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Mentors_MentorUid",
                table: "MentorValuations");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Students_StudentUid",
                table: "MentorValuations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Students_UserInfoUid",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_MentorValuations_MentorUid",
                table: "MentorValuations");

            migrationBuilder.DropIndex(
                name: "IX_MentorValuations_StudentUid",
                table: "MentorValuations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Mentors_UserInfoUid",
                table: "Mentors");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserInfoUid",
                table: "Students",
                column: "UserInfoUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_UserInfoUid",
                table: "Mentors",
                column: "UserInfoUid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Mentors_Id",
                table: "MentorValuations",
                column: "Id",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Students_Id",
                table: "MentorValuations",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
