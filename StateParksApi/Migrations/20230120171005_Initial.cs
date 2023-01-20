using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StateParksApi.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "Parks",
          columns: table => new
          {
            ParkId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            StateId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Parks", x => x.ParkId);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "States",
          columns: table => new
          {
            StateId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            ParkId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_States", x => x.StateId);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.InsertData(
          table: "Parks",
          columns: new[] { "ParkId", "Name", "StateId" },
          values: new object[,]
          {
                    { 1, "Crater Lake", 1 },
                    { 2, "Lewis and Clark", 2 },
                    { 3, "Golden Gate", 3 }
          });

      migrationBuilder.InsertData(
          table: "States",
          columns: new[] { "StateId", "Name", "ParkId" },
          values: new object[,]
          {
                    { 1, "Oregon", 1 },
                    { 2, "Washington", 2 },
                    { 3, "California", 3 }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Parks");

      migrationBuilder.DropTable(
          name: "States");
    }
  }
}
