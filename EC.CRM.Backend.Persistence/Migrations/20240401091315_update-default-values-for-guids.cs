using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    // Change this migration to firstly drop identity columns and then add newsequentialid() default values

    /// <inheritdoc />
    public partial class updatedefaultvaluesforguids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropColumn(
                name: "Uid",
                table: "UserInfos");

            // Recreate the column with the new default value
            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // StudyField
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "StudyField");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "StudyField",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // States
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "States");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // Skill
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Skill");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // Roles
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // NonProfessionalInterest
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "NonProfessionalInterest");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "NonProfessionalInterest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // Locations
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Locations");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            // Jobs
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Jobs");

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
