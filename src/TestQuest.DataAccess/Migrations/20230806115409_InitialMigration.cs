using System;
using System.Collections.Generic;
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
                    time_limit = table.Column<int>(type: "INT", nullable: false),
                    total_questions = table.Column<int>(type: "INT", nullable: false),
                    author_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATE", nullable: false),
                    category = table.Column<List<string>>(type: "text[]", nullable: false),
                    status = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false)
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
                    name = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    gender = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    age = table.Column<int>(type: "INT", maxLength: 150, nullable: false),
                    rating_points = table.Column<int>(type: "INT", nullable: false),
                    achievements = table.Column<string[]>(type: "VARCHAR[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    question = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    answer = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    options = table.Column<List<string>>(type: "VARCHAR[]", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_question_DbTestId",
                table: "question",
                column: "DbTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "result_test");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
