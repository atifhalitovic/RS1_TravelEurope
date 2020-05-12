using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _3_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Vozilo");

            migrationBuilder.AddColumn<double>(
                name: "CijenaPoDanu",
                table: "Vozilo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaPoDanu",
                table: "Vozac",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaPoDanu",
                table: "TuristRuta",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaPoDanu",
                table: "Vozilo");

            migrationBuilder.DropColumn(
                name: "CijenaPoDanu",
                table: "Vozac");

            migrationBuilder.DropColumn(
                name: "CijenaPoDanu",
                table: "TuristRuta");

            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "Vozilo",
                nullable: true);
        }
    }
}
