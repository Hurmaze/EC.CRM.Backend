using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Tiementorvaluationswithstudententitity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MentorValuations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Mentors_Id",
                table: "MentorValuations",
                column: "Id",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorValuations_Students_Id",
                table: "MentorValuations",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Mentors_Id",
                table: "MentorValuations");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorValuations_Students_Id",
                table: "MentorValuations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorValuations",
                table: "MentorValuations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MentorValuations");
        }
    }
}
