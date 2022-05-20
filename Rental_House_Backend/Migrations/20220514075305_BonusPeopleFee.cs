using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_House_Backend.Migrations
{
    public partial class BonusPeopleFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BonusPeopleFee",
                table: "otherfees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Room",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusPeopleFee",
                table: "otherfees");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "AspNetUsers");
        }
    }
}
