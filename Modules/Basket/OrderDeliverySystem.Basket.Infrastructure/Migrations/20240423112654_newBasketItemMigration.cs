using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBasketItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                schema: "basket",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets",
                column: "BasketId");

            migrationBuilder.CreateTable(
                name: "BasketItem",
                schema: "basket",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OldUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerBasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_BasketItem_Baskets_CustomerBasketId",
                        column: x => x.CustomerBasketId,
                        principalSchema: "basket",
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_CustomerBasketId",
                schema: "basket",
                table: "BasketItem",
                column: "CustomerBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductId",
                schema: "basket",
                table: "BasketItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem",
                schema: "basket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "BasketId",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets",
                column: "BuyerId");
        }
    }
}
