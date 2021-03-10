using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class RenamecolumninContractAddresstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Privince",
                table: "ContactAddress");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "ContactAddress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                table: "ContactAddress");

            migrationBuilder.AddColumn<string>(
                name: "Privince",
                table: "ContactAddress",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
