using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StateParksApi.Migrations
{
    public partial class RemoveParkIdFromStateObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkId",
                table: "States");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 1,
                column: "ParkId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 2,
                column: "ParkId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 3,
                column: "ParkId",
                value: 3);
        }
    }
}
