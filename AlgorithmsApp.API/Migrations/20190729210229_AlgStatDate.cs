using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithmsApp.Migrations
{
    public partial class AlgStatDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AlgorithmStatistics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AlgorithmStatistics");
        }
    }
}
