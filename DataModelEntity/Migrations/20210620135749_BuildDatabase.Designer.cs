﻿// <auto-generated />
using System;
using DataModelEntity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataModelEntity.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20210620135749_BuildDatabase")]
    partial class BuildDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModelEntity.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("FacultetId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Direction", b =>
                {
                    b.Property<int>("DirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectionId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Facultet", b =>
                {
                    b.Property<int>("FacultetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultetID");

                    b.ToTable("Facultets");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Grup", b =>
                {
                    b.Property<int>("GrupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectId")
                        .HasColumnType("int");

                    b.Property<int?>("DirectionListDirectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPranet")
                        .HasColumnType("bit");

                    b.HasKey("GrupId");

                    b.HasIndex("DirectionListDirectionId");

                    b.ToTable("Grups");
                });

            modelBuilder.Entity("DataModelEntity.Entity.HarvestPlan", b =>
                {
                    b.Property<int>("HarvestPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepatmentId")
                        .HasColumnType("int");

                    b.Property<int?>("GetDepartmentDepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("GrupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("HarvestPlanId");

                    b.HasIndex("GetDepartmentDepartmentId");

                    b.HasIndex("GrupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("HarvestPlans");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<int>("DirectionId")
                        .HasColumnType("int");

                    b.Property<string>("GrupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middilname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("DirectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseWork")
                        .HasColumnType("int");

                    b.Property<int>("FourOne")
                        .HasColumnType("int");

                    b.Property<int>("FourTwo")
                        .HasColumnType("int");

                    b.Property<int>("IndependentEducation")
                        .HasColumnType("int");

                    b.Property<int>("KFourOne")
                        .HasColumnType("int");

                    b.Property<int>("KFourTwo")
                        .HasColumnType("int");

                    b.Property<int>("KOneOne")
                        .HasColumnType("int");

                    b.Property<int>("KOneTwo")
                        .HasColumnType("int");

                    b.Property<int>("KThreeOne")
                        .HasColumnType("int");

                    b.Property<int>("KThreeTwo")
                        .HasColumnType("int");

                    b.Property<int>("KTwoOne")
                        .HasColumnType("int");

                    b.Property<int>("KTwoTwo")
                        .HasColumnType("int");

                    b.Property<int>("Laboratory")
                        .HasColumnType("int");

                    b.Property<int>("Lecture")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OneOne")
                        .HasColumnType("int");

                    b.Property<int>("OneTwo")
                        .HasColumnType("int");

                    b.Property<int>("Practical")
                        .HasColumnType("int");

                    b.Property<int>("Seminar")
                        .HasColumnType("int");

                    b.Property<int>("SubjectBlockTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreeOne")
                        .HasColumnType("int");

                    b.Property<int>("ThreeTwo")
                        .HasColumnType("int");

                    b.Property<int>("TwoOne")
                        .HasColumnType("int");

                    b.Property<int>("TwoTwo")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("SubjectBlockTypeId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("DataModelEntity.Entity.SubjectBlockType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubjectBlockTypes");
                });

            modelBuilder.Entity("DataModelEntity.Entity.SubjectTraingPlan", b =>
                {
                    b.Property<int>("SubjectTraingPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HardvesPlanId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("SubjectTraingPlanId");

                    b.HasIndex("HardvesPlanId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectTraingPlans");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Middilname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Department", b =>
                {
                    b.HasOne("DataModelEntity.Entity.Facultet", "GetFacultet")
                        .WithMany("GetDepartments")
                        .HasForeignKey("FacultetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetFacultet");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Grup", b =>
                {
                    b.HasOne("DataModelEntity.Entity.Direction", "DirectionList")
                        .WithMany("GetGrups")
                        .HasForeignKey("DirectionListDirectionId");

                    b.Navigation("DirectionList");
                });

            modelBuilder.Entity("DataModelEntity.Entity.HarvestPlan", b =>
                {
                    b.HasOne("DataModelEntity.Entity.Department", "GetDepartment")
                        .WithMany("GetHarvestPlans")
                        .HasForeignKey("GetDepartmentDepartmentId");

                    b.HasOne("DataModelEntity.Entity.Grup", "Grups")
                        .WithMany("HarvestPlans")
                        .HasForeignKey("GrupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModelEntity.Entity.Subject", null)
                        .WithMany("HarvestPlans")
                        .HasForeignKey("SubjectId");

                    b.HasOne("DataModelEntity.Entity.Teacher", "GetTeacher")
                        .WithMany("HarvestPlans")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDepartment");

                    b.Navigation("GetTeacher");

                    b.Navigation("Grups");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Student", b =>
                {
                    b.HasOne("DataModelEntity.Entity.Direction", "GetDirection")
                        .WithMany("Students")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDirection");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Subject", b =>
                {
                    b.HasOne("DataModelEntity.Entity.SubjectBlockType", "SubjectBlockType")
                        .WithMany("subjects")
                        .HasForeignKey("SubjectBlockTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectBlockType");
                });

            modelBuilder.Entity("DataModelEntity.Entity.SubjectTraingPlan", b =>
                {
                    b.HasOne("DataModelEntity.Entity.HarvestPlan", "HarvestPlan")
                        .WithMany("Subjects")
                        .HasForeignKey("HardvesPlanId");

                    b.HasOne("DataModelEntity.Entity.Subject", "Subject")
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectId");

                    b.Navigation("HarvestPlan");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Teacher", b =>
                {
                    b.HasOne("DataModelEntity.Entity.Department", "GetDepartment")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GetDepartment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModelEntity.Entity.Department", b =>
                {
                    b.Navigation("GetHarvestPlans");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Direction", b =>
                {
                    b.Navigation("GetGrups");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Facultet", b =>
                {
                    b.Navigation("GetDepartments");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Grup", b =>
                {
                    b.Navigation("HarvestPlans");
                });

            modelBuilder.Entity("DataModelEntity.Entity.HarvestPlan", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Subject", b =>
                {
                    b.Navigation("HarvestPlans");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DataModelEntity.Entity.SubjectBlockType", b =>
                {
                    b.Navigation("subjects");
                });

            modelBuilder.Entity("DataModelEntity.Entity.Teacher", b =>
                {
                    b.Navigation("HarvestPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
