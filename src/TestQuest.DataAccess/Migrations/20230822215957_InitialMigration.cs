using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "result_test",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    user_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    test_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    correct_answers = table.Column<int>(type: "INT", nullable: false),
                    result = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    completed_at = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result_test", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    difficulty = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    status = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    time_limit = table.Column<int>(type: "INT", nullable: false),
                    total_questions = table.Column<int>(type: "INT", nullable: false),
                    author_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    age_limit = table.Column<byte>(type: "SMALLINT", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATE", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    gender = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    age = table.Column<int>(type: "INT", maxLength: 150, nullable: false),
                    rating_points = table.Column<int>(type: "INT", nullable: false),
                    achievements = table.Column<string[]>(type: "VARCHAR[]", nullable: false),
                    role = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question_answer",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    question_text = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    answer = table.Column<string>(type: "VARCHAR", nullable: false),
                    correct_answer = table.Column<string>(type: "VARCHAR", nullable: false),
                    status = table.Column<string>(type: "VARCHAR", nullable: false),
                    ResultTestId = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_answer", x => x.id);
                    table.ForeignKey(
                        name: "result_test_id",
                        column: x => x.ResultTestId,
                        principalTable: "result_test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    category = table.Column<string>(type: "VARCHAR", nullable: false),
                    test_id = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "category",
                        column: x => x.test_id,
                        principalTable: "test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment_and_test_score",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    comment_text = table.Column<string>(type: "VARCHAR", maxLength: 5000, nullable: false),
                    score = table.Column<byte>(type: "SMALLINT", nullable: false),
                    test_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    user_id = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_and_test_score", x => x.id);
                    table.ForeignKey(
                        name: "comment_and_test_scores",
                        column: x => x.test_id,
                        principalTable: "test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    question = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    answer = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    test_id = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.id);
                    table.ForeignKey(
                        name: "comment_and_test_scores",
                        column: x => x.test_id,
                        principalTable: "test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    option = table.Column<string>(type: "VARCHAR", nullable: false),
                    question_id = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_options_question_question_id",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_test_id",
                table: "category",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_and_test_score_test_id",
                table: "comment_and_test_score",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_question_id",
                table: "options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_test_id",
                table: "question",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_ResultTestId",
                table: "question_answer",
                column: "ResultTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "comment_and_test_score");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "question_answer");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "result_test");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
