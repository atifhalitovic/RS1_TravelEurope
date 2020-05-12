using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _3_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "RacunId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "RacunId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
