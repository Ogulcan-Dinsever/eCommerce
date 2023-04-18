using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Persistence.Migrations
{
    public partial class postgresql6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Discount",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discount");
        }
    }
}
