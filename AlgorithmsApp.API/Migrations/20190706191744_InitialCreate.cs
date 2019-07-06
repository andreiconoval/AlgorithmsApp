using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithmsApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Algorithms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Algorithms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MockDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetOfData = table.Column<string>(nullable: true),
                    NumberOfElements = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlgorithmStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlgorithmId = table.Column<int>(nullable: false),
                    MockDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlgorithmStatistics_Algorithms_AlgorithmId",
                        column: x => x.AlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlgorithmStatistics_MockDatas_MockDataId",
                        column: x => x.MockDataId,
                        principalTable: "MockDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlgorithmStatistics_AlgorithmId",
                table: "AlgorithmStatistics",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_AlgorithmStatistics_MockDataId",
                table: "AlgorithmStatistics",
                column: "MockDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmStatistics");

            migrationBuilder.DropTable(
                name: "Algorithms");

            migrationBuilder.DropTable(
                name: "MockDatas");
        }
    }
}
