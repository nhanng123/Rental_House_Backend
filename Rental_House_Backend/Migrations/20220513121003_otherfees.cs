using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_House_Backend.Migrations
{
    public partial class otherfees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "otherfees",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectricFee = table.Column<int>(type: "int", nullable: false),
                    WaterFee = table.Column<int>(type: "int", nullable: false),
                    GarbageFee = table.Column<int>(type: "int", nullable: false),
                    WifiFee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otherfees", x => x.AreaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "otherfees");
        }
    }
}
