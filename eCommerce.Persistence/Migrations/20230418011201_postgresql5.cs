using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Persistence.Migrations
{
    public partial class postgresql5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "Discount");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Discount",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Discount");

            migrationBuilder.AddColumn<List<int>>(
                name: "CategoryIds",
                table: "Discount",
                type: "integer[]",
                nullable: true);
        }
    }
}
