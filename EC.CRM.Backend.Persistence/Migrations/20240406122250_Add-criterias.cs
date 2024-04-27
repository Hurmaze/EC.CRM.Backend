using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addcriterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criterias",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    IsBeneficial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterias", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "MentorValuations",
                columns: table => new
                {
                    MentorUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valuation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criterias");

            migrationBuilder.DropTable(
                name: "MentorValuations");
        }
    }
}
