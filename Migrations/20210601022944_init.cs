using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passWord = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActived = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeAccount = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    difficulty = table.Column<int>(type: "int", nullable: false),
                    isPublic = table.Column<bool>(type: "bit", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timeLimit = table.Column<float>(type: "real", nullable: false),
                    memoryLimit = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeNotification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNotification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    isHidden = table.Column<bool>(type: "bit", nullable: false),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    rootCommentID = table.Column<int>(type: "int", nullable: true),
                    postID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts_accountID",
                        column: x => x.accountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_rootCommentID",
                        column: x => x.rootCommentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleAuthors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articleID = table.Column<int>(type: "int", nullable: false),
                    authorID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAuthors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleAuthors_Accounts_authorID",
                        column: x => x.authorID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleAuthors_Articles_articleID",
                        column: x => x.articleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemAuthors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problemID = table.Column<int>(type: "int", nullable: false),
                    authorID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemAuthors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProblemAuthors_Accounts_authorID",
                        column: x => x.authorID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemAuthors_Problems_problemID",
                        column: x => x.problemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemClassifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problemID = table.Column<int>(type: "int", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemClassifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProblemClassifications_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemClassifications_Problems_problemID",
                        column: x => x.problemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    problemID = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<float>(type: "real", nullable: false),
                    memory = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Submissions_Accounts_accountID",
                        column: x => x.accountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Problems_problemID",
                        column: x => x.problemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    output = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestCases_Problems_problemID",
                        column: x => x.problemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    seen = table.Column<bool>(type: "bit", nullable: false),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    objectID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    typeNotificationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_accountID",
                        column: x => x.accountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_TypeNotification_typeNotificationID",
                        column: x => x.typeNotificationID,
                        principalTable: "TypeNotification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountID = table.Column<int>(type: "int", nullable: false),
                    commentID = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Likes_Accounts_accountID",
                        column: x => x.accountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_commentID",
                        column: x => x.commentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    submissionID = table.Column<int>(type: "int", nullable: false),
                    testCaseID = table.Column<int>(type: "int", nullable: true),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    excuteTime = table.Column<float>(type: "real", nullable: false),
                    memory = table.Column<float>(type: "real", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubmissionResults_Submissions_submissionID",
                        column: x => x.submissionID,
                        principalTable: "Submissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmissionResults_TestCases_testCaseID",
                        column: x => x.testCaseID,
                        principalTable: "TestCases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthors_articleID",
                table: "ArticleAuthors",
                column: "articleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthors_authorID",
                table: "ArticleAuthors",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_accountID",
                table: "Comments",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_rootCommentID",
                table: "Comments",
                column: "rootCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_accountID",
                table: "Likes",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_commentID",
                table: "Likes",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_accountID",
                table: "Notifications",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_typeNotificationID",
                table: "Notifications",
                column: "typeNotificationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemAuthors_authorID",
                table: "ProblemAuthors",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemAuthors_problemID",
                table: "ProblemAuthors",
                column: "problemID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemClassifications_categoryID",
                table: "ProblemClassifications",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemClassifications_problemID",
                table: "ProblemClassifications",
                column: "problemID");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionResults_submissionID",
                table: "SubmissionResults",
                column: "submissionID");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionResults_testCaseID",
                table: "SubmissionResults",
                column: "testCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_accountID",
                table: "Submissions",
                column: "accountID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_problemID",
                table: "Submissions",
                column: "problemID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_problemID",
                table: "TestCases",
                column: "problemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleAuthors");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProblemAuthors");

            migrationBuilder.DropTable(
                name: "ProblemClassifications");

            migrationBuilder.DropTable(
                name: "SubmissionResults");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TypeNotification");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Problems");
        }
    }
}
