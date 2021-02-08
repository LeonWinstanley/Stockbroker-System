using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkAPI.Migrations.Stock
{
    public partial class InitalCreateStockDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandleData",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Close = table.Column<decimal>(type: "TEXT", nullable: false),
                    High = table.Column<decimal>(type: "TEXT", nullable: false),
                    Low = table.Column<decimal>(type: "TEXT", nullable: false),
                    Open = table.Column<decimal>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Volume = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandleData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StocksData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanySymbol = table.Column<string>(type: "TEXT", nullable: true),
                    AvailableShares = table.Column<double>(type: "REAL", nullable: false),
                    StockPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandleData");

            migrationBuilder.DropTable(
                name: "StocksData");
        }
    }
}
