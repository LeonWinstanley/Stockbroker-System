using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkWebapp.Migrations
{
    public partial class changeDoubleToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalanceAvailable",
                table: "AccountDetails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "AccountBalance",
                table: "AccountDetails",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalanceConverted",
                table: "AccountDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalanceConverted",
                table: "AccountDetails");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalanceAvailable",
                table: "AccountDetails",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "AccountDetails",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
