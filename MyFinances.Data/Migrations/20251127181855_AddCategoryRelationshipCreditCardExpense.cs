using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryRelationshipCreditCardExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM Categories WHERE Id = 1)
                BEGIN
                    SET IDENTITY_INSERT Categories ON;

                    INSERT INTO Categories (Id, Name, Description, IsActive, CreatedAt)
                    VALUES (1, 'GERAL', 'Categoria padrão do sistema', 1, GETDATE());

                    SET IDENTITY_INSERT Categories OFF;
                END
            ");
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CreditCardExpenses",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardExpenses_CategoryId",
                table: "CreditCardExpenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardExpenses_Categories_CategoryId",
                table: "CreditCardExpenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardExpenses_Categories_CategoryId",
                table: "CreditCardExpenses");

            migrationBuilder.DropIndex(
                name: "IX_CreditCardExpenses_CategoryId",
                table: "CreditCardExpenses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CreditCardExpenses");
        }
    }
}
