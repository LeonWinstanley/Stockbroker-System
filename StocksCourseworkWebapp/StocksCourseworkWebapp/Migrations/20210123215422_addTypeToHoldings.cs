using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkWebapp.Migrations
{
    public partial class addTypeToHoldings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "UserHoldings",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserHoldings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserHoldings");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "UserHoldings",
                newName: "amount");
        }
    }
}
