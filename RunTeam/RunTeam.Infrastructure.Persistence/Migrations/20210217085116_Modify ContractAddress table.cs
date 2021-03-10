using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class ModifyContractAddresstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "ContactAddress");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ContactAddress",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ContactAddress");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "ContactAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
