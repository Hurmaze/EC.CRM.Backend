using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addjoinddateforusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "UserInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "UserInfos");
        }
    }
}
