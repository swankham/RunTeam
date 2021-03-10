using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class Addeventstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    EventCode = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    RegistrationStartDate = table.Column<DateTime>(nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(nullable: false),
                    EventStartDate = table.Column<DateTime>(nullable: false),
                    EventEndDate = table.Column<DateTime>(nullable: false),
                    EnableFlag = table.Column<bool>(nullable: false),
                    OnlineFlag = table.Column<bool>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    RegistrationStatus = table.Column<int>(nullable: false),
                    EventOwner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
