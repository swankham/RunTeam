using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class ModifyPersonaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhone",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthIssues",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "PersonalDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "HealthIssues",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "PersonalDetails");
        }
    }
}
