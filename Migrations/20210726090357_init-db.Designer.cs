﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBL3.Data;

namespace PBL3.Migrations
{
    [DbContext(typeof(PBL3Context))]
    [Migration("20210726090357_init-db")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("accountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("avar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("isActived")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("passWord")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("roleID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            accountName = "Admin",
                            email = "trannhutri0703@gmail.com",
                            firstName = "",
                            isActived = true,
                            isDeleted = false,
                            lastName = "Admin",
                            passWord = "E10ADC3949BA59ABBE56E057F20F883E",
                            roleID = 1,
                            timeCreate = new DateTime(2021, 7, 26, 16, 3, 57, 240, DateTimeKind.Local).AddTicks(1588)
                        });
                });

            modelBuilder.Entity("PBL3.Models.Action", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("objectID")
                        .HasColumnType("int");

                    b.Property<int>("typeObject")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("accountID");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("PBL3.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("topicID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("topicID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PBL3.Models.ArticleAuthor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("articleID")
                        .HasColumnType("int");

                    b.Property<int>("authorID")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("articleID");

                    b.HasIndex("authorID");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("PBL3.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PBL3.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isHidden")
                        .HasColumnType("bit");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<int>("postID")
                        .HasColumnType("int");

                    b.Property<int?>("rootCommentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("typePost")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("accountID");

                    b.HasIndex("rootCommentID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PBL3.Models.Like", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<int?>("commentID")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("accountID");

                    b.HasIndex("commentID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("PBL3.Models.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("objectID")
                        .HasColumnType("int");

                    b.Property<bool>("seen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("typeNotification")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("accountID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PBL3.Models.Problem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("difficulty")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isPublic")
                        .HasColumnType("bit");

                    b.Property<int?>("memoryLimit")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.Property<float?>("timeLimit")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("PBL3.Models.ProblemAuthor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("authorID")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("problemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("authorID");

                    b.HasIndex("problemID");

                    b.ToTable("ProblemAuthors");
                });

            modelBuilder.Entity("PBL3.Models.ProblemClassification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TopicID")
                        .HasColumnType("int");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("problemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TopicID");

                    b.HasIndex("categoryID");

                    b.HasIndex("problemID");

                    b.ToTable("ProblemClassifications");
                });

            modelBuilder.Entity("PBL3.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            name = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            name = "Author"
                        },
                        new
                        {
                            ID = 3,
                            name = "User"
                        });
                });

            modelBuilder.Entity("PBL3.Models.Submission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("language")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("memory")
                        .HasColumnType("real");

                    b.Property<int>("problemID")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("time")
                        .HasColumnType("real");

                    b.Property<DateTime>("timeCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("accountID");

                    b.HasIndex("problemID");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("PBL3.Models.SubmissionResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("excuteTime")
                        .HasColumnType("real");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("memory")
                        .HasColumnType("real");

                    b.Property<string>("result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("submissionID")
                        .HasColumnType("int");

                    b.Property<int?>("testCaseID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("submissionID");

                    b.HasIndex("testCaseID");

                    b.ToTable("SubmissionResults");
                });

            modelBuilder.Entity("PBL3.Models.TestCase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("problemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("problemID");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("PBL3.Models.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("describeImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ID");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("PBL3.Models.Account", b =>
                {
                    b.HasOne("PBL3.Models.Role", "role")
                        .WithMany("accounts")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("PBL3.Models.Action", b =>
                {
                    b.HasOne("PBL3.Models.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("PBL3.Models.Article", b =>
                {
                    b.HasOne("PBL3.Models.Topic", "topic")
                        .WithMany()
                        .HasForeignKey("topicID");

                    b.Navigation("topic");
                });

            modelBuilder.Entity("PBL3.Models.ArticleAuthor", b =>
                {
                    b.HasOne("PBL3.Models.Article", "article")
                        .WithMany("articleAuthors")
                        .HasForeignKey("articleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Account", "author")
                        .WithMany("articleAuthors")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");

                    b.Navigation("author");
                });

            modelBuilder.Entity("PBL3.Models.Comment", b =>
                {
                    b.HasOne("PBL3.Models.Account", "account")
                        .WithMany("comments")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Comment", "rootComment")
                        .WithMany("child")
                        .HasForeignKey("rootCommentID");

                    b.Navigation("account");

                    b.Navigation("rootComment");
                });

            modelBuilder.Entity("PBL3.Models.Like", b =>
                {
                    b.HasOne("PBL3.Models.Account", "account")
                        .WithMany("likes")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Comment", "comment")
                        .WithMany("likes")
                        .HasForeignKey("commentID");

                    b.Navigation("account");

                    b.Navigation("comment");
                });

            modelBuilder.Entity("PBL3.Models.Notification", b =>
                {
                    b.HasOne("PBL3.Models.Account", "account")
                        .WithMany("notifications")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("PBL3.Models.ProblemAuthor", b =>
                {
                    b.HasOne("PBL3.Models.Account", "author")
                        .WithMany("problemAuthors")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Problem", "problem")
                        .WithMany("problemAuthors")
                        .HasForeignKey("problemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("problem");
                });

            modelBuilder.Entity("PBL3.Models.ProblemClassification", b =>
                {
                    b.HasOne("PBL3.Models.Topic", null)
                        .WithMany("articles")
                        .HasForeignKey("TopicID");

                    b.HasOne("PBL3.Models.Category", "category")
                        .WithMany("problemClassifications")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Problem", "problem")
                        .WithMany("problemClassifications")
                        .HasForeignKey("problemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("problem");
                });

            modelBuilder.Entity("PBL3.Models.Submission", b =>
                {
                    b.HasOne("PBL3.Models.Account", "account")
                        .WithMany("submissions")
                        .HasForeignKey("accountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.Problem", "problem")
                        .WithMany("submissions")
                        .HasForeignKey("problemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");

                    b.Navigation("problem");
                });

            modelBuilder.Entity("PBL3.Models.SubmissionResult", b =>
                {
                    b.HasOne("PBL3.Models.Submission", "submission")
                        .WithMany("submissionResults")
                        .HasForeignKey("submissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PBL3.Models.TestCase", "testCase")
                        .WithMany("submitResults")
                        .HasForeignKey("testCaseID");

                    b.Navigation("submission");

                    b.Navigation("testCase");
                });

            modelBuilder.Entity("PBL3.Models.TestCase", b =>
                {
                    b.HasOne("PBL3.Models.Problem", "problem")
                        .WithMany("testCases")
                        .HasForeignKey("problemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("problem");
                });

            modelBuilder.Entity("PBL3.Models.Account", b =>
                {
                    b.Navigation("articleAuthors");

                    b.Navigation("comments");

                    b.Navigation("likes");

                    b.Navigation("notifications");

                    b.Navigation("problemAuthors");

                    b.Navigation("submissions");
                });

            modelBuilder.Entity("PBL3.Models.Article", b =>
                {
                    b.Navigation("articleAuthors");
                });

            modelBuilder.Entity("PBL3.Models.Category", b =>
                {
                    b.Navigation("problemClassifications");
                });

            modelBuilder.Entity("PBL3.Models.Comment", b =>
                {
                    b.Navigation("child");

                    b.Navigation("likes");
                });

            modelBuilder.Entity("PBL3.Models.Problem", b =>
                {
                    b.Navigation("problemAuthors");

                    b.Navigation("problemClassifications");

                    b.Navigation("submissions");

                    b.Navigation("testCases");
                });

            modelBuilder.Entity("PBL3.Models.Role", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("PBL3.Models.Submission", b =>
                {
                    b.Navigation("submissionResults");
                });

            modelBuilder.Entity("PBL3.Models.TestCase", b =>
                {
                    b.Navigation("submitResults");
                });

            modelBuilder.Entity("PBL3.Models.Topic", b =>
                {
                    b.Navigation("articles");
                });
#pragma warning restore 612, 618
        }
    }
}