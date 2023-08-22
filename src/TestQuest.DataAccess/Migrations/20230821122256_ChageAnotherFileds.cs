using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChageAnotherFileds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "test",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AgeLimit",
                table: "test",
                newName: "age_limit");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "options",
                newName: "question_id");

            migrationBuilder.RenameIndex(
                name: "IX_options_QuestionId",
                table: "options",
                newName: "IX_options_question_id");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "category",
                newName: "test_id");

            migrationBuilder.RenameIndex(
                name: "IX_category_TestId",
                table: "category",
                newName: "IX_category_test_id");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "test",
                type: "VARCHAR",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte>(
                name: "age_limit",
                table: "test",
                type: "SMALLINT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "test",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "age_limit",
                table: "test",
                newName: "AgeLimit");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "options",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_options_question_id",
                table: "options",
                newName: "IX_options_QuestionId");

            migrationBuilder.RenameColumn(
                name: "test_id",
                table: "category",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_category_test_id",
                table: "category",
                newName: "IX_category_TestId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "test",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<byte>(
                name: "AgeLimit",
                table: "test",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "SMALLINT");
        }
    }
}
