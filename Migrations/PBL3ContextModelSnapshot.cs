﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBL3.Data;

namespace PBL3.Migrations
{
    [DbContext(typeof(PBL3Context))]
    partial class PBL3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PBL3.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Actived")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PBL3.Models.Problem", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("SuccessRate")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Problem");
                });

            modelBuilder.Entity("PBL3.Models.Submission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSubmit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Time")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ProblemID");

                    b.ToTable("Submission");
                });

            modelBuilder.Entity("PBL3.Models.SubmitResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubmissionID")
                        .HasColumnType("int");

                    b.Property<int>("TestCaseID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubmissionID");

                    b.HasIndex("TestCaseID");

                    b.ToTable("SubmitResult");
                });

            modelBuilder.Entity("PBL3.Models.TestCase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("ProblemID");

                    b.ToTable("TestCase");
                });

            modelBuilder.Entity("PBL3.Models.Submission", b =>
                {
                    b.HasOne("PBL3.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Problem", "Problem")
                        .WithMany()
                        .HasForeignKey("ProblemID");

                    b.Navigation("Account");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("PBL3.Models.SubmitResult", b =>
                {
                    b.HasOne("PBL3.Models.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TestCaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");

                    b.Navigation("TestCase");
                });

            modelBuilder.Entity("PBL3.Models.TestCase", b =>
                {
                    b.HasOne("PBL3.Models.Problem", "Problem")
                        .WithMany()
                        .HasForeignKey("ProblemID");

                    b.Navigation("Problem");
                });
#pragma warning restore 612, 618
        }
    }
}
