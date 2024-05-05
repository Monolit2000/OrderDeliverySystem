using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBAsskdfksgjsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.EnsureSchema(
                name: "Basket");

            migrationBuilder.RenameTable(
                name: "Baskets",
                schema: "basket",
                newName: "Basket",
                newSchema: "Basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket",
                column: "CustomerBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Basket_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId",
                principalSchema: "Basket",
                principalTable: "Basket",
                principalColumn: "CustomerBasketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Basket_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                schema: "Basket",
                newName: "Baskets",
                newSchema: "basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets",
                column: "CustomerBasketId");
        }
    }
}
