using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelEurope.Data.Migrations
{
    public partial class _1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GradId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column<string>(nullable: false),
                    IzjavaZastitaPodataka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrator_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentId = table.Column<string>(nullable: false),
                    BrojPasosa = table.Column<string>(nullable: true),
                    BrVozackeDozvole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentId);
                    table.ForeignKey(
                        name: "FK_Klijent_AspNetUsers_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarkaVozila",
                columns: table => new
                {
                    MarkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaVozila", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    NacinPlacanjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    RadnikId = table.Column<string>(nullable: false),
                    Pozicija = table.Column<string>(nullable: true),
                    GodineStaza = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikId);
                    table.ForeignKey(
                        name: "FK_Radnik_AspNetUsers_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusVozaca",
                columns: table => new
                {
                    StatusVozacaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dostupan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVozaca", x => x.StatusVozacaId);
                });

            migrationBuilder.CreateTable(
                name: "StatusVozila",
                columns: table => new
                {
                    StatusVozilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    Ispravnost = table.Column<bool>(nullable: false),
                    Rezervisano = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVozila", x => x.StatusVozilaId);
                });

            migrationBuilder.CreateTable(
                name: "TipVozila",
                columns: table => new
                {
                    TipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipVozila", x => x.TipId);
                });

            migrationBuilder.CreateTable(
                name: "TuristickiVodic",
                columns: table => new
                {
                    TuristickiVodicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    StraniJezik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristickiVodic", x => x.TuristickiVodicId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaGoriva",
                columns: table => new
                {
                    GorivoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaGoriva", x => x.GorivoId);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradId);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.LokacijaId);
                    table.ForeignKey(
                        name: "FK_Lokacija_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    VozacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    BrVozackeDozvole = table.Column<string>(nullable: true),
                    StatusVozacaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.VozacId);
                    table.ForeignKey(
                        name: "FK_Vozac_StatusVozaca_StatusVozacaId",
                        column: x => x.StatusVozacaId,
                        principalTable: "StatusVozaca",
                        principalColumn: "StatusVozacaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TuristRuta",
                columns: table => new
                {
                    TuristRutaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    TuristickiVodicId = table.Column<int>(nullable: false),
                    DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristRuta", x => x.TuristRutaId);
                    table.ForeignKey(
                        name: "FK_TuristRuta_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuristRuta_TuristickiVodic_TuristickiVodicId",
                        column: x => x.TuristickiVodicId,
                        principalTable: "TuristickiVodic",
                        principalColumn: "TuristickiVodicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    VoziloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    TipVozilaId = table.Column<int>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    MarkaVozilaId = table.Column<int>(nullable: false),
                    StatusVozilaId = table.Column<int>(nullable: false),
                    VrstaGorivaId = table.Column<int>(nullable: false),
                    BrojSjedista = table.Column<int>(nullable: false),
                    Boja = table.Column<string>(nullable: true),
                    BrojVrata = table.Column<int>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.VoziloId);
                    table.ForeignKey(
                        name: "FK_Vozilo_MarkaVozila_MarkaVozilaId",
                        column: x => x.MarkaVozilaId,
                        principalTable: "MarkaVozila",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_StatusVozila_StatusVozilaId",
                        column: x => x.StatusVozilaId,
                        principalTable: "StatusVozila",
                        principalColumn: "StatusVozilaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_TipVozila_TipVozilaId",
                        column: x => x.TipVozilaId,
                        principalTable: "TipVozila",
                        principalColumn: "TipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_VrstaGoriva_VrstaGorivaId",
                        column: x => x.VrstaGorivaId,
                        principalTable: "VrstaGoriva",
                        principalColumn: "GorivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPreuzimanja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: false),
                    CijenaUslugePoDanu = table.Column<double>(nullable: false),
                    CijenaOsiguranja = table.Column<double>(nullable: false),
                    KlijentId = table.Column<string>(nullable: true),
                    RadnikId = table.Column<string>(nullable: true),
                    VozacId = table.Column<int>(nullable: true),
                    VoziloId = table.Column<int>(nullable: true),
                    TuristRutaId = table.Column<int>(nullable: true),
                    RacunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Radnik_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnik",
                        principalColumn: "RadnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_TuristRuta_TuristRutaId",
                        column: x => x.TuristRutaId,
                        principalTable: "TuristRuta",
                        principalColumn: "TuristRutaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Vozac_VozacId",
                        column: x => x.VozacId,
                        principalTable: "Vozac",
                        principalColumn: "VozacId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RezervacijaId = table.Column<int>(nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    TrajanjeRentanjaDani = table.Column<int>(nullable: false),
                    NacinPlacanjaId = table.Column<int>(nullable: false),
                    CijenaUslugeSaPDVom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunId);
                    table.ForeignKey(
                        name: "FK_Racun_NacinPlacanja_NacinPlacanjaId",
                        column: x => x.NacinPlacanjaId,
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradId",
                table: "AspNetUsers",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_DrzavaId",
                table: "Lokacija",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_NacinPlacanjaId",
                table: "Racun",
                column: "NacinPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_RezervacijaId",
                table: "Racun",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KlijentId",
                table: "Rezervacija",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_RacunId",
                table: "Rezervacija",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_RadnikId",
                table: "Rezervacija",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_TuristRutaId",
                table: "Rezervacija",
                column: "TuristRutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VozacId",
                table: "Rezervacija",
                column: "VozacId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VoziloId",
                table: "Rezervacija",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_TuristRuta_DrzavaId",
                table: "TuristRuta",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_TuristRuta_TuristickiVodicId",
                table: "TuristRuta",
                column: "TuristickiVodicId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozac_StatusVozacaId",
                table: "Vozac",
                column: "StatusVozacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_MarkaVozilaId",
                table: "Vozilo",
                column: "MarkaVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_StatusVozilaId",
                table: "Vozilo",
                column: "StatusVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_TipVozilaId",
                table: "Vozilo",
                column: "TipVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VrstaGorivaId",
                table: "Vozilo",
                column: "VrstaGorivaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grad_GradId",
                table: "AspNetUsers",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "GradId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AspNetUsers_Grad_GradId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TuristRuta_Drzava_DrzavaId",
                table: "TuristRuta");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_NacinPlacanja_NacinPlacanjaId",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Rezervacija_RezervacijaId",
                table: "Racun");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropTable(
                name: "TuristRuta");

            migrationBuilder.DropTable(
                name: "Vozac");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "TuristickiVodic");

            migrationBuilder.DropTable(
                name: "StatusVozaca");

            migrationBuilder.DropTable(
                name: "MarkaVozila");

            migrationBuilder.DropTable(
                name: "StatusVozila");

            migrationBuilder.DropTable(
                name: "TipVozila");

            migrationBuilder.DropTable(
                name: "VrstaGoriva");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GradId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GradId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "AspNetUsers");
        }
    }
}
