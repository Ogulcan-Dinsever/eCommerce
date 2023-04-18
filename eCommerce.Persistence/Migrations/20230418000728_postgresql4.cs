using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Persistence.Migrations
{
    public partial class postgresql4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandIds",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Product");

            migrationBuilder.AddColumn<List<int>>(
                name: "BrandIds",
                table: "Product",
                type: "integer[]",
                nullable: true);
        }
    }
}
