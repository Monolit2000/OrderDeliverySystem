using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImageUrlMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryDateTime",
                schema: "basket",
                table: "BasketItems",
                newName: "deliveryDateTime");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                schema: "basket",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "deliveryDateTime",
                schema: "basket",
                table: "BasketItems",
                newName: "DeliveryDateTime");
        }
    }
}
