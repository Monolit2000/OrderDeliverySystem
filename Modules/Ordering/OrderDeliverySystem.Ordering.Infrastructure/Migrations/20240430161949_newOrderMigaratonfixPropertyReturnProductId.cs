using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newOrderMigaratonfixPropertyReturnProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "ordering",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "ordering",
                table: "OrderItems");
        }
    }
}
