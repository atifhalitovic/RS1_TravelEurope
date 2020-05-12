using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _3_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija");

            migrationBuilder.AlterColumn<int>(
                name: "RacunId",
                table: "Rezervacija",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "RacunId",
                table: "Rezervacija",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Racun_RacunId",
                table: "Rezervacija",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "RacunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
