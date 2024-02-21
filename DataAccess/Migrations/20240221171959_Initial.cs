using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Good!", "Margherita", 10m },
                    { 2, "Good!", "Pepperoni", 12m },
                    { 3, "Cool!", "Hawaiian", 11m },
                    { 4, "Very good!", "Meat Lover's", 13m },
                    { 5, "Very good!", "Veggie Supreme", 11m },
                    { 6, "Good!", "BBQ Chicken", 12m },
                    { 7, "Very good!", "Supreme", 10m },
                    { 8, "Good!", "Cheese Lover's", 11m },
                    { 9, "Cool!", "Buffalo Chicken", 12m },
                    { 10, "Cool!", "Mediterranean", 13m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
