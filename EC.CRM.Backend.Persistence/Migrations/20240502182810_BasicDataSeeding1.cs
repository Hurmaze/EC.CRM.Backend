using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EC.CRM.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BasicDataSeeding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MentorPropertiesUid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentPropertiesUid",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MentorUid",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Uid", "Address", "City" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Ковальский провулок 19", "Київ" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "вулиця Травнева, 10, Броварський район, Київська область, 07443", "Калинівка" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "вулиця Відродження 31, Волиньска область, 43000", "Луцьк" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), null, "Online" }
                });

            migrationBuilder.InsertData(
                table: "NonProfessionalInterest",
                columns: new[] { "Uid", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Читання" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Писання" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Малювання" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Живопис" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Фотографія" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Гра на музичних інструментах" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Спів" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Танці" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Кулінарія" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Пекарство" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "Садівництво" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "Походи в гори" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "Кемпінг" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "Риболовля" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "Спостереження за птахами" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "В'язання" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "В'язання гачком" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Шиття" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "Гончарство" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "Скульптура" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "Робота з деревом" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "DIY проекти" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "Збір марок" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "Збір монет" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "Збір антикваріату" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "Збір винтажних речей" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "Збір коміксів" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "Збір фігурок" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "Збір спортивної меморабілії" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "Дивитися фільми" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "Дивитися телешоу" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "Грати в відеоігри" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "Настільні ігри" },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "Розв'язування пазлів" },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "Кросворди" },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "Судоку" },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "Йога" },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "Медитація" },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "Біг" },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "Джоггінг" },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "Велосипед" },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "Плавання" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "Серфінг" },
                    { new Guid("00000000-0000-0000-0000-000000000051"), "Катання на лижах" },
                    { new Guid("00000000-0000-0000-0000-000000000052"), "Сноубординг" },
                    { new Guid("00000000-0000-0000-0000-000000000053"), "Скейтбординг" },
                    { new Guid("00000000-0000-0000-0000-000000000054"), "Скелелазіння" },
                    { new Guid("00000000-0000-0000-0000-000000000055"), "Настільний теніс" },
                    { new Guid("00000000-0000-0000-0000-000000000056"), "Теніс" },
                    { new Guid("00000000-0000-0000-0000-000000000057"), "Волейбол" },
                    { new Guid("00000000-0000-0000-0000-000000000058"), "Футбол" },
                    { new Guid("00000000-0000-0000-0000-000000000059"), "Баскетбол" },
                    { new Guid("00000000-0000-0000-0000-000000000060"), "Інший спорт" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Uid", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Director" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Mentor" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Uid", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000061"), "Java" },
                    { new Guid("00000000-0000-0000-0000-000000000062"), "Python" },
                    { new Guid("00000000-0000-0000-0000-000000000063"), "JavaScript/TypeScript" },
                    { new Guid("00000000-0000-0000-0000-000000000064"), "Powershell" },
                    { new Guid("00000000-0000-0000-0000-000000000065"), "Bash" },
                    { new Guid("00000000-0000-0000-0000-000000000066"), "CMD" },
                    { new Guid("00000000-0000-0000-0000-000000000067"), "Linux" },
                    { new Guid("00000000-0000-0000-0000-000000000068"), "CSS" },
                    { new Guid("00000000-0000-0000-0000-000000000069"), "Html" },
                    { new Guid("00000000-0000-0000-0000-000000000070"), "Other programming languages" },
                    { new Guid("00000000-0000-0000-0000-000000000071"), "SQL" },
                    { new Guid("00000000-0000-0000-0000-000000000072"), "MsSQL" },
                    { new Guid("00000000-0000-0000-0000-000000000073"), "Postgres" },
                    { new Guid("00000000-0000-0000-0000-000000000074"), "MySql" },
                    { new Guid("00000000-0000-0000-0000-000000000075"), "AWS" },
                    { new Guid("00000000-0000-0000-0000-000000000076"), "Azure services" },
                    { new Guid("00000000-0000-0000-0000-000000000077"), "Git" },
                    { new Guid("00000000-0000-0000-0000-000000000078"), "GitHub CI" },
                    { new Guid("00000000-0000-0000-0000-000000000079"), "GitLab CI" },
                    { new Guid("00000000-0000-0000-0000-000000000080"), "Azure Devops CI" },
                    { new Guid("00000000-0000-0000-0000-000000000081"), "Jenkins" },
                    { new Guid("00000000-0000-0000-0000-000000000082"), "Allure" },
                    { new Guid("00000000-0000-0000-0000-000000000083"), "React" },
                    { new Guid("00000000-0000-0000-0000-000000000084"), "Angular" },
                    { new Guid("00000000-0000-0000-0000-000000000085"), "ASP.NET" },
                    { new Guid("00000000-0000-0000-0000-000000000086"), "Spring Boot" },
                    { new Guid("00000000-0000-0000-0000-000000000087"), "Junit" },
                    { new Guid("00000000-0000-0000-0000-000000000088"), "TestNG" },
                    { new Guid("00000000-0000-0000-0000-000000000089"), "NUnit" },
                    { new Guid("00000000-0000-0000-0000-000000000090"), "XUnit" },
                    { new Guid("00000000-0000-0000-0000-000000000091"), "Mocha" },
                    { new Guid("00000000-0000-0000-0000-000000000092"), "C#" },
                    { new Guid("00000000-0000-0000-0000-000000000093"), "Pytest" },
                    { new Guid("00000000-0000-0000-0000-000000000094"), "Playwright" },
                    { new Guid("00000000-0000-0000-0000-000000000095"), "Selenium" },
                    { new Guid("00000000-0000-0000-0000-000000000096"), "Selenide" },
                    { new Guid("00000000-0000-0000-0000-000000000097"), "Selenoid" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Uid", "Name", "OrderingId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000200"), "Робота над тестовим завданням", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000201"), "Випробовувальний період", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "Навчається", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "Ходить по співбесідам", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "Отримав роботу", 0 }
                });

            migrationBuilder.InsertData(
                table: "StudyField",
                columns: new[] { "Uid", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000100"), "QA/AQA" },
                    { new Guid("00000000-0000-0000-0000-000000000101"), "Frontend" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "Full stack" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "Backend" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"));

            migrationBuilder.DeleteData(
                table: "NonProfessionalInterest",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"));

            migrationBuilder.DeleteData(
                table: "StudyField",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "StudyField",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "StudyField",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "StudyField",
                keyColumn: "Uid",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DropColumn(
                name: "MentorPropertiesUid",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "StudentPropertiesUid",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "MentorUid",
                table: "Students");
        }
    }
}
