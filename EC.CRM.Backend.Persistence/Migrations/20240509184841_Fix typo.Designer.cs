﻿// <auto-generated />
using System;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EC.CRM.Backend.Persistence.Migrations
{
    [DbContext(typeof(EngineeringClubDbContext))]
    [Migration("20240509184841_Fix typo")]
    partial class Fixtypo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Credentials", b =>
                {
                    b.Property<Guid>("UserInfoUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserInfoUid");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(10, 3)
                        .HasColumnType("decimal");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserInfoUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Uid");

                    b.HasIndex("UserInfoUid");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Uid");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserInfoUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoUid")
                        .IsUnique();

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.NonProfessionalInterest", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Uid");

                    b.ToTable("NonProfessionalInterest");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Uid");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Uid");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.State", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderingId")
                        .HasColumnType("int");

                    b.HasKey("Uid");

                    b.ToTable("States");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<Guid>("StateUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserInfoUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("StateUid");

                    b.HasIndex("UserInfoUid")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.StudyField", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Uid");

                    b.ToTable("StudyField");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.TOPSIS.Criteria", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsBeneficial")
                        .HasColumnType("bit");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Criterias");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.TOPSIS.MentorValuation", b =>
                {
                    b.Property<Guid>("MentorUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Valuation")
                        .HasColumnType("float");

                    b.ToTable("MentorValuations");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.UserInfo", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<decimal?>("CurrentSalary")
                        .HasPrecision(10, 3)
                        .HasColumnType("decimal");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Paid")
                        .HasPrecision(10, 3)
                        .HasColumnType("decimal");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("RoleUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Uid");

                    b.HasIndex("RoleUid");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("LocationUserInfo", b =>
                {
                    b.Property<Guid>("LocationsUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationsUid", "UsersUid");

                    b.HasIndex("UsersUid");

                    b.ToTable("LocationUserInfo");
                });

            modelBuilder.Entity("NonProfessionalInterestUserInfo", b =>
                {
                    b.Property<Guid>("NonProfessionalInterestsUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NonProfessionalInterestsUid", "UsersUid");

                    b.HasIndex("UsersUid");

                    b.ToTable("NonProfessionalInterestUserInfo");
                });

            modelBuilder.Entity("SkillUserInfo", b =>
                {
                    b.Property<Guid>("SkillsUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SkillsUid", "UsersUid");

                    b.HasIndex("UsersUid");

                    b.ToTable("SkillUserInfo");
                });

            modelBuilder.Entity("StudyFieldUserInfo", b =>
                {
                    b.Property<Guid>("StudyFieldsUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudyFieldsUid", "UsersUid");

                    b.HasIndex("UsersUid");

                    b.ToTable("StudyFieldUserInfo");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Credentials", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", "User")
                        .WithOne("Credentials")
                        .HasForeignKey("EC.CRM.Backend.Domain.Entities.Credentials", "UserInfoUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Job", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", "UserInfo")
                        .WithMany("Jobs")
                        .HasForeignKey("UserInfoUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Mentor", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", "UserInfo")
                        .WithOne("MentorProperties")
                        .HasForeignKey("EC.CRM.Backend.Domain.Entities.Mentor", "UserInfoUid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Student", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.Mentor", "Mentor")
                        .WithMany("Students")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.State", "State")
                        .WithMany("Students")
                        .HasForeignKey("StateUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", "UserInfo")
                        .WithOne("StudentProperties")
                        .HasForeignKey("EC.CRM.Backend.Domain.Entities.Student", "UserInfoUid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("State");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.UserInfo", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.Role", "Role")
                        .WithMany("UserInfos")
                        .HasForeignKey("RoleUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LocationUserInfo", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationsUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UsersUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NonProfessionalInterestUserInfo", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.NonProfessionalInterest", null)
                        .WithMany()
                        .HasForeignKey("NonProfessionalInterestsUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UsersUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillUserInfo", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UsersUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyFieldUserInfo", b =>
                {
                    b.HasOne("EC.CRM.Backend.Domain.Entities.StudyField", null)
                        .WithMany()
                        .HasForeignKey("StudyFieldsUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EC.CRM.Backend.Domain.Entities.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UsersUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Mentor", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.State", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EC.CRM.Backend.Domain.Entities.UserInfo", b =>
                {
                    b.Navigation("Credentials")
                        .IsRequired();

                    b.Navigation("Jobs");

                    b.Navigation("MentorProperties");

                    b.Navigation("StudentProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
