using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class nina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adminstrator",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminstrator", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearnerId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    AdminstratorId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Adminstrator_AdminstratorId",
                        column: x => x.AdminstratorId,
                        principalTable: "Adminstrator",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: true),
                    LearnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheQuizzes_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TheQuizzes_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    LearnerId = table.Column<int>(type: "int", nullable: true),
                    AdminstratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Adminstrator_AdminstratorId",
                        column: x => x.AdminstratorId,
                        principalTable: "Adminstrator",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Content_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseLearner",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    LearnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearner", x => new { x.CoursesId, x.LearnersId });
                    table.ForeignKey(
                        name: "FK_CourseLearner_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LearnerId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Learner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Learner_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Learner_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LearnerId = table.Column<int>(type: "int", nullable: true),
                    FeedbackId = table.Column<int>(type: "int", nullable: true),
                    TheQuizzesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Feedback_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedback",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quiz_Learner_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quiz_TheQuizzes_TheQuizzesId",
                        column: x => x.TheQuizzesId,
                        principalTable: "TheQuizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adminstrator_AccountId",
                table: "Adminstrator",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Adminstrator_ContentId",
                table: "Adminstrator",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminstratorId",
                table: "AspNetUsers",
                column: "AdminstratorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstructorId",
                table: "AspNetUsers",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LearnerId",
                table: "AspNetUsers",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_LearnerId",
                table: "Certificate",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_QuizId",
                table: "Certificate",
                column: "QuizId",
                unique: true,
                filter: "[QuizId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Content_AdminstratorId",
                table: "Content",
                column: "AdminstratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CourseId",
                table: "Content",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_LearnerId",
                table: "Content",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearner_LearnersId",
                table: "CourseLearner",
                column: "LearnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_InstructorId",
                table: "Feedback",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_LearnerId",
                table: "Feedback",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_QuizId",
                table: "Feedback",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_AccountId",
                table: "Instructor",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Learner_AccountId",
                table: "Learner",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Learner_ContentId",
                table: "Learner",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Learner_QuizId",
                table: "Learner",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_FeedbackId",
                table: "Quiz",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_LearnerId",
                table: "Quiz",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_TheQuizzesId",
                table: "Quiz",
                column: "TheQuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_TheQuizzes_CertificateId",
                table: "TheQuizzes",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_TheQuizzes_InstructorId",
                table: "TheQuizzes",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminstrator_AspNetUsers_AccountId",
                table: "Adminstrator",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminstrator_Content_ContentId",
                table: "Adminstrator",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Instructor_InstructorId",
                table: "AspNetUsers",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Learner_LearnerId",
                table: "AspNetUsers",
                column: "LearnerId",
                principalTable: "Learner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Learner_LearnerId",
                table: "Certificate",
                column: "LearnerId",
                principalTable: "Learner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_TheQuizzes_QuizId",
                table: "Certificate",
                column: "QuizId",
                principalTable: "TheQuizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Learner_LearnerId",
                table: "Content",
                column: "LearnerId",
                principalTable: "Learner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLearner_Learner_LearnersId",
                table: "CourseLearner",
                column: "LearnersId",
                principalTable: "Learner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Learner_LearnerId",
                table: "Feedback",
                column: "LearnerId",
                principalTable: "Learner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Quiz_QuizId",
                table: "Feedback",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Learner_Quiz_QuizId",
                table: "Learner",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminstrator_AspNetUsers_AccountId",
                table: "Adminstrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_AspNetUsers_AccountId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Learner_AspNetUsers_AccountId",
                table: "Learner");

            migrationBuilder.DropForeignKey(
                name: "FK_Adminstrator_Content_ContentId",
                table: "Adminstrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Learner_Content_ContentId",
                table: "Learner");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Instructor_InstructorId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TheQuizzes_Instructor_InstructorId",
                table: "TheQuizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Learner_LearnerId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Learner_LearnerId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Learner_LearnerId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_TheQuizzes_QuizId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_TheQuizzes_TheQuizzesId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Quiz_QuizId",
                table: "Feedback");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseLearner");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Adminstrator");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Learner");

            migrationBuilder.DropTable(
                name: "TheQuizzes");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
