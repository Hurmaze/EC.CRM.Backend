using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGuidDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9160c3e3-1e03-437b-80e4-6f2a6969bac5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MentorUid",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("264ed747-09ff-4b1c-ac70-928131d1e079"),
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4225857e-fb08-45fe-97b9-246490b8bf16"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac2ff5c7-6f17-4513-966c-3d6452df2072"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Mentors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4c887ca2-9632-4f2b-8921-00a6c4bc194b"),
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9311b2ec-5c93-4de7-82ee-47b48c575f82"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bdcba20a-8834-4f40-bd59-760692f3b4ee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9160c3e3-1e03-437b-80e4-6f2a6969bac5"));

            migrationBuilder.AlterColumn<int>(
                name: "MentorUid",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Uid",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("264ed747-09ff-4b1c-ac70-928131d1e079"))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4225857e-fb08-45fe-97b9-246490b8bf16"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac2ff5c7-6f17-4513-966c-3d6452df2072"));

            migrationBuilder.AlterColumn<int>(
                name: "Uid",
                table: "Mentors",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4c887ca2-9632-4f2b-8921-00a6c4bc194b"))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9311b2ec-5c93-4de7-82ee-47b48c575f82"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bdcba20a-8834-4f40-bd59-760692f3b4ee"));
        }
    }
}
