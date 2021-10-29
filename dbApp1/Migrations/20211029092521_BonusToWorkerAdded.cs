using Microsoft.EntityFrameworkCore.Migrations;

namespace dbApp1.Migrations
{
    public partial class BonusToWorkerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Bonus",
                table: "WORKER",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "WORKER");
        }
    }
}
