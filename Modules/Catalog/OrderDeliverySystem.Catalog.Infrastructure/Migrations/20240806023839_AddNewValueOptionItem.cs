using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewValueOptionItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUri",
                schema: "catalog",
                table: "Catalog",
                newName: "PictureUri");

            migrationBuilder.AddColumn<string>(
                name: "OptionItem_Description",
                schema: "catalog",
                table: "Catalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionItem_Name",
                schema: "catalog",
                table: "Catalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OptionItem_Price",
                schema: "catalog",
                table: "Catalog",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionItem_Description",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "OptionItem_Name",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "OptionItem_Price",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.RenameColumn(
                name: "PictureUri",
                schema: "catalog",
                table: "Catalog",
                newName: "PictureUri");
        }
    }
}
