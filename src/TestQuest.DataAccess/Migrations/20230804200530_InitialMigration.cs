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
                    Id = table.Column<string>(type: "text", nullable: false),
                    id_user = table.Column<string>(type: "text", nullable: false),
                    correct_answers = table.Column<byte>(type: "TINYINT", maxLength: 255, nullable: false),
                    result = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    completed_at = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result_test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    difficulty = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    time_limit = table.Column<byte>(type: "TINYINT", maxLength: 255, nullable: false),
                    total_questions = table.Column<byte>(type: "TINYINT", maxLength: 255, nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Category = table.Column<List<string>>(type: "text[]", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    gender = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    age = table.Column<byte>(type: "TINYINT", maxLength: 150, nullable: false),
                    RatingPoints = table.Column<int>(type: "integer", nullable: false),
                    Achievements = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "close_question",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    question = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    answer = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    options = table.Column<List<string>>(type: "text[]", nullable: false),
                    DbTestId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_close_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_close_question_test_DbTestId",
                        column: x => x.DbTestId,
                        principalTable: "test",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_close_question_DbTestId",
                table: "close_question",
                column: "DbTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "close_question");

            migrationBuilder.DropTable(
                name: "result_test");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
