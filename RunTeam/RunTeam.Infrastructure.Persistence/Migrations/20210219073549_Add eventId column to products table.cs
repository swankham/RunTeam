using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class AddeventIdcolumntoproductstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Products");
        }
    }
}
