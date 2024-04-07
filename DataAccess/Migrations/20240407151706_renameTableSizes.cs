using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class renameTableSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzasSizes_PizzasSizeId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzasSizes");

            migrationBuilder.RenameColumn(
                name: "PizzasSizeId",
                table: "Pizzas",
                newName: "PizzaSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_PizzasSizeId",
                table: "Pizzas",
                newName: "IX_Pizzas_PizzaSizeId");

            migrationBuilder.CreateTable(
                name: "PizzaSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diametr = table.Column<int>(type: "int", nullable: false),
                    PriceModifier = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PizzaSizes",
                columns: new[] { "Id", "Diametr", "PriceModifier" },
                values: new object[,]
                {
                    { 1, 10, 1m },
                    { 2, 30, 3m },
                    { 3, 50, 5m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaSizes_PizzaSizeId",
                table: "Pizzas",
                column: "PizzaSizeId",
                principalTable: "PizzaSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaSizes_PizzaSizeId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaSizes");

            migrationBuilder.RenameColumn(
                name: "PizzaSizeId",
                table: "Pizzas",
                newName: "PizzasSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_PizzaSizeId",
                table: "Pizzas",
                newName: "IX_Pizzas_PizzasSizeId");

            migrationBuilder.CreateTable(
                name: "PizzasSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diametr = table.Column<int>(type: "int", nullable: false),
                    PriceModifier = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzasSizes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PizzasSizes",
                columns: new[] { "Id", "Diametr", "PriceModifier" },
                values: new object[,]
                {
                    { 1, 30, 2m },
                    { 2, 15, 1m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzasSizes_PizzasSizeId",
                table: "Pizzas",
                column: "PizzasSizeId",
                principalTable: "PizzasSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
