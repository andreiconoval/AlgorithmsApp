using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithmsApp.Migrations
{
    public partial class ExecutedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExecutedTime",
                table: "AlgorithmStatistics",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutedTime",
                table: "AlgorithmStatistics");
        }
    }
}
