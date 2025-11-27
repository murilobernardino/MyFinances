using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixParentCategoryNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParenCategoryId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParenCategoryId",
                table: "Categories",
                type: "int",
                nullable: true);
        }
    }
}
