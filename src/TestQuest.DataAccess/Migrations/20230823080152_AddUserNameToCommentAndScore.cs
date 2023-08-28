using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameToCommentAndScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "comment_and_test_score",
                type: "VARCHAR",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_name",
                table: "comment_and_test_score");
        }
    }
}
