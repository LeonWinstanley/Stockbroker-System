using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchangeAPI.Migrations
{
    public partial class initalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Base = table.Column<string>(type: "TEXT", nullable: true),
                    ExchangeCurrency = table.Column<string>(type: "TEXT", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchanges", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyExchanges");
        }
    }
}
