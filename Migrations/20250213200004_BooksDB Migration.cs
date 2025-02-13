using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDepo.Api.Migrations
{
    /// <inheritdoc />
    public partial class BooksDBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    book_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    stock_available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
