using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewConfigureMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.EnsureSchema(
                name: "Basket");

            migrationBuilder.RenameTable(
                name: "Baskets",
                schema: "basket",
                newName: "Basket",
                newSchema: "Basket");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                schema: "basket",
                newName: "BasketItem",
                newSchema: "Basket");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "Basket",
                table: "BasketItem",
                newName: "IX_BasketItem_CustomerBasketId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                schema: "Basket",
                table: "BasketItem",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImageUrl",
                schema: "Basket",
                table: "BasketItem",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "OptionItem_Description",
                schema: "Basket",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionItem_Name",
                schema: "Basket",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OptionItem_Price",
                schema: "Basket",
                table: "BasketItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket",
                column: "CustomerBasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                schema: "Basket",
                table: "BasketItem",
                column: "BasketItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Basket_CustomerBasketId",
                schema: "Basket",
                table: "BasketItem",
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
                name: "FK_BasketItem_Basket_CustomerBasketId",
                schema: "Basket",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                schema: "Basket",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "OptionItem_Description",
                schema: "Basket",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "OptionItem_Name",
                schema: "Basket",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "OptionItem_Price",
                schema: "Basket",
                table: "BasketItem");

            migrationBuilder.EnsureSchema(
                name: "basket");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                schema: "Basket",
                newName: "BasketItems",
                newSchema: "basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                schema: "Basket",
                newName: "Baskets",
                newSchema: "basket");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                newName: "IX_BasketItems_CustomerBasketId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                schema: "basket",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImageUrl",
                schema: "basket",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                schema: "basket",
                table: "BasketItems",
                column: "BasketItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "CustomerBasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
