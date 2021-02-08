using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkWebapp.Migrations
{
    public partial class addedAmountToUserHoldings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "UserHoldings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "UserHoldings");
        }
    }
}
