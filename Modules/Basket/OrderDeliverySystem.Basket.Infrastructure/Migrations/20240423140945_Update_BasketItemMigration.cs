using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_BasketItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItem");

            migrationBuilder.RenameColumn(
                name: "CustomerBasketId",
                schema: "basket",
                table: "BasketItem",
                newName: "BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_CustomerBasketId",
                schema: "basket",
                table: "BasketItem",
                newName: "IX_BasketItem_BasketId");

            migrationBuilder.AddColumn<long>(
                name: "BuyerChatId",
                schema: "basket",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                schema: "basket",
                table: "BasketItem",
                column: "BasketId",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                schema: "basket",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "BuyerChatId",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                schema: "basket",
                table: "BasketItem",
                newName: "CustomerBasketId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_BasketId",
                schema: "basket",
                table: "BasketItem",
                newName: "IX_BasketItem_CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItem",
                column: "CustomerBasketId",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
