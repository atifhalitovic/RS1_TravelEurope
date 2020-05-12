using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _2_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GodinaProizvodnje",
                table: "Vozilo",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GodinaProizvodnje",
                table: "Vozilo",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
