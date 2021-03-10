using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTeam.Infrastructure.Persistence.Migrations
{
    public partial class Modifyproductstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Products",
                newName: "PricePerUnit");

            migrationBuilder.AddColumn<bool>(
                name: "CustomerOrderFlag",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CutOffTimeMin",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EnableFlag",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndActiveDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemCatalogId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryUomCode",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationStatus",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Segment1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segment2",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segment3",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segment4",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segment5",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServiceItemFlag",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShippableItemFlag",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartActiveDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerOrderFlag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CutOffTimeMin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EnableFlag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndActiveDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItemCatalogId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PrimaryUomCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RegistrationStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Segment1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Segment2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Segment3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Segment4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Segment5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ServiceItemFlag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippableItemFlag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StartActiveDate",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                table: "Products",
                newName: "Rate");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
