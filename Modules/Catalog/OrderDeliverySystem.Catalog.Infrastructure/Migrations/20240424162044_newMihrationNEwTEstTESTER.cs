using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMihrationNEwTEstTESTER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "catalog",
                columns: table => new
                {
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.CatalogItemId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                schema: "catalog",
                columns: table => new
                {
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.CatalogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Establishments",
                schema: "catalog",
                columns: table => new
                {
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishments", x => x.EstablishmentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogTypes",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Establishments",
                schema: "catalog");
        }
    }
}
