﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Property<long>("ApplicantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Applicant_BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Applicant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicant_Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantID");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.Property<long>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ApplicantID")
                        .HasColumnType("bigint");

                    b.Property<long>("ApplicationStatusID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Application_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Application_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GradeID")
                        .HasColumnType("bigint");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("ApplicantID");

                    b.HasIndex("ApplicationStatusID");

                    b.HasIndex("GradeID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Property<long>("ApplicationStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationStatus_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationtStatus_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicationStatusID");

                    b.ToTable("ApplicationStatuses");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Property<long>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade_Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Grade_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Grade_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grade_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade_Number")
                        .HasColumnType("int");

                    b.HasKey("GradeID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("DAL.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Person_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.HasOne("DAL.Entities.Applicant", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ApplicationStatus", "ApplicationStatus")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicationStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Grade", "Grade")
                        .WithMany("Applications")
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
