using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new_TestMigration__DatabaseTesBasketTestnewTEssdfdfgsjfsag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerChatId",
                schema: "Basket",
                table: "Basket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyerChatId",
                schema: "Basket",
                table: "Basket",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
