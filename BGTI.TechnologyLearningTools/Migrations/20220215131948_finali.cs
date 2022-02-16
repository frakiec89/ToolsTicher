using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BGTI.TechnologyLearningTools.Migrations
{
    public partial class finali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    UserTestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => x.UserTestId);
                    table.ForeignKey(
                        name: "FK_UserTests_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTestQuestions",
                columns: table => new
                {
                    UserTestQuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserTestId = table.Column<int>(type: "INTEGER", nullable: false),
                    Otvet = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestQuestions", x => x.UserTestQuestionId);
                    table.ForeignKey(
                        name: "FK_UserTestQuestions_UserTests_UserTestId",
                        column: x => x.UserTestId,
                        principalTable: "UserTests",
                        principalColumn: "UserTestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTestQuestions_UserTestId",
                table: "UserTestQuestions",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_ExamId",
                table: "UserTests",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTestQuestions");

            migrationBuilder.DropTable(
                name: "UserTests");
        }
    }
}
