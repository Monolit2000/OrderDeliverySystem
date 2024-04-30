using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newOrderMigaratonfixPropertyProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "ordering",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "ordering",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
