using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChagneForeignKeyInResultTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "questions_answers",
                table: "question_answer");

            migrationBuilder.AddColumn<string>(
                name: "ResultTestId",
                table: "question_answer",
                type: "VARCHAR",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_ResultTestId",
                table: "question_answer",
                column: "ResultTestId");

            migrationBuilder.AddForeignKey(
                name: "result_test_id",
                table: "question_answer",
                column: "ResultTestId",
                principalTable: "result_test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "result_test_id",
                table: "question_answer");

            migrationBuilder.DropIndex(
                name: "IX_question_answer_ResultTestId",
                table: "question_answer");

            migrationBuilder.DropColumn(
                name: "ResultTestId",
                table: "question_answer");

            migrationBuilder.AddForeignKey(
                name: "questions_answers",
                table: "question_answer",
                column: "id",
                principalTable: "result_test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
