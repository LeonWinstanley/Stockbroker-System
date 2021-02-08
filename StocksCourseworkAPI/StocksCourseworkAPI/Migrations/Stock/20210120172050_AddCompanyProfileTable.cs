using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkAPI.Migrations.Stock
{
    public partial class AddCompanyProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyProfile",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Exchange = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: true),
                    IpoDate = table.Column<string>(type: "TEXT", nullable: true),
                    MarketCapitalization = table.Column<int>(type: "INTEGER", nullable: false),
                    SharesOutstanding = table.Column<double>(type: "REAL", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Industry = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfile", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfile");
        }
    }
}
