using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newOrderMigaratonfixPropertyTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buyer",
                schema: "orders",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "buyer",
                schema: "orders",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
