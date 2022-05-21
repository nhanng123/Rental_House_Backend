using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_House_Backend.Migrations
{
    public partial class updateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hometown",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hometown",
                table: "customers");
        }
    }
}
