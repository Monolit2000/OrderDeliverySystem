using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newOrderMigaratonBuyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyerChatId",
                schema: "ordering",
                table: "Buyers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerChatId",
                schema: "ordering",
                table: "Buyers");
        }
    }
}
