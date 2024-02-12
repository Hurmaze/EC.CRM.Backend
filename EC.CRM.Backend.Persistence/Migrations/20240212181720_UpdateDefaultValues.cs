using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Mentors_MentorUid",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_MentorUid",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MentorUid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Mentors");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("73f8447e-8b35-4f32-adac-9fe9876529cf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9160c3e3-1e03-437b-80e4-6f2a6969bac5"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("14f705dc-a2af-437e-88a2-c6b6a90c1d2a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4225857e-fb08-45fe-97b9-246490b8bf16"));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("940c8245-661d-4d10-b948-a5edbe18dee4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac2ff5c7-6f17-4513-966c-3d6452df2072"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mentors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6fce367f-9c02-4b7e-9604-6f0004afd83f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9311b2ec-5c93-4de7-82ee-47b48c575f82"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9132b8a0-071c-467f-a146-becf9256dde4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bdcba20a-8834-4f40-bd59-760692f3b4ee"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MentorId",
                table: "Students",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Mentors_MentorId",
                table: "Students",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Mentors_MentorId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_MentorId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mentors");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9160c3e3-1e03-437b-80e4-6f2a6969bac5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("73f8447e-8b35-4f32-adac-9fe9876529cf"));

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("264ed747-09ff-4b1c-ac70-928131d1e079"));

            migrationBuilder.AddColumn<Guid>(
                name: "MentorUid",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4225857e-fb08-45fe-97b9-246490b8bf16"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("14f705dc-a2af-437e-88a2-c6b6a90c1d2a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac2ff5c7-6f17-4513-966c-3d6452df2072"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("940c8245-661d-4d10-b948-a5edbe18dee4"));

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "Mentors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4c887ca2-9632-4f2b-8921-00a6c4bc194b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9311b2ec-5c93-4de7-82ee-47b48c575f82"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6fce367f-9c02-4b7e-9604-6f0004afd83f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bdcba20a-8834-4f40-bd59-760692f3b4ee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9132b8a0-071c-467f-a146-becf9256dde4"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MentorUid",
                table: "Students",
                column: "MentorUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Mentors_MentorUid",
                table: "Students",
                column: "MentorUid",
                principalTable: "Mentors",
                principalColumn: "Uid");
        }
    }
}
