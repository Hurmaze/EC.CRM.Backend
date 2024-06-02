using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Makementorvaluationcompositekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MentorValuations");

            migrationBuilder.DropIndex(
                name: "IX_MentorValuations_StudentUid",
                table: "MentorValuations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations",
                columns: new[] { "StudentUid", "MentorUid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MentorValuations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MentorValuations_StudentUid",
                table: "MentorValuations",
                column: "StudentUid");
        }
    }
}
