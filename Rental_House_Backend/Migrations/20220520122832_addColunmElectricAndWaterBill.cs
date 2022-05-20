using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_House_Backend.Migrations
{
    public partial class addColunmElectricAndWaterBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Old_Number",
                table: "waterbills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "waterbills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "waterbills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Electric_Price",
                table: "electricbills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Old_Number",
                table: "electricbills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "electricbills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Old_Number",
                table: "waterbills");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "waterbills");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "waterbills");

            migrationBuilder.DropColumn(
                name: "Electric_Price",
                table: "electricbills");

            migrationBuilder.DropColumn(
                name: "Old_Number",
                table: "electricbills");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "electricbills");
        }
    }
}
