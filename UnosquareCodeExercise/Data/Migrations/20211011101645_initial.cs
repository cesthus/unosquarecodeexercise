using Microsoft.EntityFrameworkCore.Migrations;

namespace UnosquareCodeExerciseAPI.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AgeRestriccion = table.Column<int>(type: "int", nullable: true),
                    Company = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriccion", "Company", "Description", "Name", "Price" },
                values: new object[] { 1, 12, "Mattel", "", "Barbie Developer", 25.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriccion", "Company", "Description", "Name", "Price" },
                values: new object[] { 2, 4, "Marvel", "", "xyc", 75.5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriccion", "Company", "Description", "Name", "Price" },
                values: new object[] { 3, 18, "Nintendo", "", "abc", 99.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
