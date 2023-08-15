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
                    id_user = table.Column<string>(type: "VARCHAR", nullable: false),
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
                    AgeLimit = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATE", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
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
                name: "category",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    category = table.Column<string>(type: "VARCHAR", nullable: false),
                    TestId = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "category",
                        column: x => x.TestId,
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
                    DbTestId = table.Column<string>(type: "VARCHAR", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_test_DbTestId",
                        column: x => x.DbTestId,
                        principalTable: "test",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    option = table.Column<string>(type: "VARCHAR", nullable: false),
                    QuestionId = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.id);
                    table.ForeignKey(
                        name: "options",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_TestId",
                table: "category",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_options_QuestionId",
                table: "options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_question_DbTestId",
                table: "question",
                column: "DbTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "result_test");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
