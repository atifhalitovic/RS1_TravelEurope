using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _4_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_RacunId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "RacunId",
                table: "Rezervacija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RacunId",
                table: "Rezervacija",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_RacunId",
                table: "Rezervacija",
                column: "RacunId");

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
