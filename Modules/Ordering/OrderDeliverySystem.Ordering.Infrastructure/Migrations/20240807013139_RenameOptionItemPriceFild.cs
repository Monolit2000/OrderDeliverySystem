using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameOptionItemPriceFild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionItemNamePrice",
                schema: "ordering",
                table: "OrderItems",
                newName: "OptionItemPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionItemPrice",
                schema: "ordering",
                table: "OrderItems",
                newName: "OptionItemNamePrice");
        }
    }
}
