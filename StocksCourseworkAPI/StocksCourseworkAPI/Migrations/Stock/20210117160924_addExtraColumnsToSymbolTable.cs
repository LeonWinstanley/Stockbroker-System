using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkAPI.Migrations.Stock
{
    public partial class addExtraColumnsToSymbolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "SymbolData",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Figi",
                table: "SymbolData",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mic",
                table: "SymbolData",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SymbolData",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "SymbolData");

            migrationBuilder.DropColumn(
                name: "Figi",
                table: "SymbolData");

            migrationBuilder.DropColumn(
                name: "Mic",
                table: "SymbolData");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SymbolData");
        }
    }
}
