using Microsoft.EntityFrameworkCore.Migrations;

namespace BGTI.TechnologyLearningTools.Migrations
{
    public partial class Test55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "QuestionOption");

            migrationBuilder.RenameIndex(
                name: "IX_Options_QuestionId",
                table: "QuestionOption",
                newName: "IX_QuestionOption_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOption",
                table: "QuestionOption",
                column: "QuestionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOption_Questions_QuestionId",
                table: "QuestionOption",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOption_Questions_QuestionId",
                table: "QuestionOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOption",
                table: "QuestionOption");

            migrationBuilder.RenameTable(
                name: "QuestionOption",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionOption_QuestionId",
                table: "Options",
                newName: "IX_Options_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "QuestionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
