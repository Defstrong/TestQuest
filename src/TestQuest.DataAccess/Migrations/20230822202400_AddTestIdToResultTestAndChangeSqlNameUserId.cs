using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTestIdToResultTestAndChangeSqlNameUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "result_test",
                newName: "user_id");

            migrationBuilder.AddColumn<string>(
                name: "test_id",
                table: "result_test",
                type: "VARCHAR",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test_id",
                table: "result_test");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "result_test",
                newName: "id_user");
        }
    }
}
