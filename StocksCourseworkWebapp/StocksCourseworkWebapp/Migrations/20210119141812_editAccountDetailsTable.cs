using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksCourseworkWebapp.Migrations
{
    public partial class editAccountDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "loggedIn",
                table: "AccountDetails");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AccountDetails",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AccountDetails",
                newName: "AccountBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AccountDetails",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "AccountBalance",
                table: "AccountDetails",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AccountDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AccountDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "loggedIn",
                table: "AccountDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
