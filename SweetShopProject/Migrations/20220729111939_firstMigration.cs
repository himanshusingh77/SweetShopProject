using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetShopProject.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    imgpath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    catID = table.Column<int>(type: "int", nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_catID",
                        column: x => x.catID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_product_cities_cityID",
                        column: x => x.cityID,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    finalAmount = table.Column<float>(type: "real", nullable: false),
                    prodID = table.Column<int>(type: "int", nullable: false),
                    catID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_cart_category_catID",
                        column: x => x.catID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_cart_product_prodID",
                        column: x => x.prodID,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantityAvail = table.Column<int>(type: "int", nullable: false),
                    totalQuantity = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    prodID = table.Column<int>(type: "int", nullable: false),
                    catID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_category_catID",
                        column: x => x.catID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_inventory_product_prodID",
                        column: x => x.prodID,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_catID",
                table: "cart",
                column: "catID");

            migrationBuilder.CreateIndex(
                name: "IX_cart_prodID",
                table: "cart",
                column: "prodID");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_catID",
                table: "inventory",
                column: "catID");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodID",
                table: "inventory",
                column: "prodID");

            migrationBuilder.CreateIndex(
                name: "IX_product_catID",
                table: "product",
                column: "catID");

            migrationBuilder.CreateIndex(
                name: "IX_product_cityID",
                table: "product",
                column: "cityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
