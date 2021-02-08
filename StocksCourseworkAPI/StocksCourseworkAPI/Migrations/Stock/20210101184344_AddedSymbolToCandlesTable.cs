using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkAPI.Migrations.Stock
{
    public partial class AddedSymbolToCandlesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "CandleData",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "CandleData");
        }
    }
}
