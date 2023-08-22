using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentAndTestScoreTableForTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment_and_test_score",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", nullable: false),
                    comment_text = table.Column<string>(type: "VARCHAR", maxLength: 5000, nullable: false),
                    score = table.Column<byte>(type: "SMALLINT", nullable: false),
                    test_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_comment_and_test_score_test_id",
                table: "comment_and_test_score",
                column: "test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_and_test_score");
        }
    }
}
