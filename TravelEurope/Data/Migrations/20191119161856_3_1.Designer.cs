﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelEurope.Data;

namespace TravelEurope.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191119161856_3_1")]
    partial class _3_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TravelEurope.Models.Administrator", b =>
                {
                    b.Property<string>("AdministratorId");

                    b.Property<string>("IzjavaZastitaPodataka");

                    b.HasKey("AdministratorId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("TravelEurope.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Adresa");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prezime");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Slika");

                    b.Property<string>("Spol");

                    b.Property<string>("Telefon");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TravelEurope.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("TravelEurope.Models.Grad", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.HasKey("GradId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("TravelEurope.Models.Klijent", b =>
                {
                    b.Property<string>("KlijentId");

                    b.Property<string>("BrVozackeDozvole");

                    b.Property<string>("BrojPasosa");

                    b.HasKey("KlijentId");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("TravelEurope.Models.Lokacija", b =>
                {
                    b.Property<int>("LokacijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.HasKey("LokacijaId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("TravelEurope.Models.MarkaVozila", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("MarkaId");

                    b.ToTable("MarkaVozila");
                });

            modelBuilder.Entity("TravelEurope.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("NacinPlacanjaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("NacinPlacanjaId");

                    b.ToTable("NacinPlacanja");
                });

            modelBuilder.Entity("TravelEurope.Models.Racun", b =>
                {
                    b.Property<int>("RacunId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CijenaUslugeSaPDVom");

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<int>("NacinPlacanjaId");

                    b.Property<int>("RezervacijaId");

                    b.Property<int>("TrajanjeRentanjaDani");

                    b.HasKey("RacunId");

                    b.HasIndex("NacinPlacanjaId");

                    b.HasIndex("RezervacijaId");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("TravelEurope.Models.Radnik", b =>
                {
                    b.Property<string>("RadnikId");

                    b.Property<int>("GodineStaza");

                    b.Property<string>("Pozicija");

                    b.HasKey("RadnikId");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("TravelEurope.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CijenaOsiguranja");

                    b.Property<double>("CijenaUslugePoDanu");

                    b.Property<DateTime>("DatumPreuzimanja");

                    b.Property<DateTime>("DatumVracanja");

                    b.Property<string>("KlijentId");

                    b.Property<int>("RacunId");

                    b.Property<string>("RadnikId");

                    b.Property<int?>("TuristRutaId");

                    b.Property<int?>("VozacId");

                    b.Property<int?>("VoziloId");

                    b.HasKey("RezervacijaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("RacunId");

                    b.HasIndex("RadnikId");

                    b.HasIndex("TuristRutaId");

                    b.HasIndex("VozacId");

                    b.HasIndex("VoziloId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("TravelEurope.Models.StatusVozaca", b =>
                {
                    b.Property<int>("StatusVozacaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Dostupan");

                    b.HasKey("StatusVozacaId");

                    b.ToTable("StatusVozaca");
                });

            modelBuilder.Entity("TravelEurope.Models.StatusVozila", b =>
                {
                    b.Property<int>("StatusVozilaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ispravnost");

                    b.Property<bool>("Rezervisano");

                    b.Property<string>("Status");

                    b.HasKey("StatusVozilaId");

                    b.ToTable("StatusVozila");
                });

            modelBuilder.Entity("TravelEurope.Models.TipVozila", b =>
                {
                    b.Property<int>("TipId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("TipId");

                    b.ToTable("TipVozila");
                });

            modelBuilder.Entity("TravelEurope.Models.TuristickiVodic", b =>
                {
                    b.Property<int>("TuristickiVodicId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("StraniJezik");

                    b.HasKey("TuristickiVodicId");

                    b.ToTable("TuristickiVodic");
                });

            modelBuilder.Entity("TravelEurope.Models.TuristRuta", b =>
                {
                    b.Property<int>("TuristRutaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CijenaPoDanu");

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<int>("TuristickiVodicId");

                    b.HasKey("TuristRutaId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("TuristickiVodicId");

                    b.ToTable("TuristRuta");
                });

            modelBuilder.Entity("TravelEurope.Models.Vozac", b =>
                {
                    b.Property<int>("VozacId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrVozackeDozvole");

                    b.Property<double>("CijenaPoDanu");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<int>("StatusVozacaId");

                    b.HasKey("VozacId");

                    b.HasIndex("StatusVozacaId");

                    b.ToTable("Vozac");
                });

            modelBuilder.Entity("TravelEurope.Models.Vozilo", b =>
                {
                    b.Property<int>("VoziloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boja");

                    b.Property<int>("BrojSjedista");

                    b.Property<int>("BrojVrata");

                    b.Property<double>("CijenaPoDanu");

                    b.Property<int>("GodinaProizvodnje");

                    b.Property<int>("MarkaVozilaId");

                    b.Property<string>("Naziv");

                    b.Property<int>("StatusVozilaId");

                    b.Property<int>("TipVozilaId");

                    b.Property<int>("VrstaGorivaId");

                    b.HasKey("VoziloId");

                    b.HasIndex("MarkaVozilaId");

                    b.HasIndex("StatusVozilaId");

                    b.HasIndex("TipVozilaId");

                    b.HasIndex("VrstaGorivaId");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("TravelEurope.Models.VrstaGoriva", b =>
                {
                    b.Property<int>("GorivoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("GorivoId");

                    b.ToTable("VrstaGoriva");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Administrator", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.ApplicationUser", b =>
                {
                    b.HasOne("TravelEurope.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Grad", b =>
                {
                    b.HasOne("TravelEurope.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Klijent", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Lokacija", b =>
                {
                    b.HasOne("TravelEurope.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Racun", b =>
                {
                    b.HasOne("TravelEurope.Models.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanjaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Radnik", b =>
                {
                    b.HasOne("TravelEurope.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Rezervacija", b =>
                {
                    b.HasOne("TravelEurope.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId");

                    b.HasOne("TravelEurope.Models.Racun", "Racun")
                        .WithMany()
                        .HasForeignKey("RacunId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId");

                    b.HasOne("TravelEurope.Models.TuristRuta", "TuristRuta")
                        .WithMany()
                        .HasForeignKey("TuristRutaId");

                    b.HasOne("TravelEurope.Models.Vozac", "Vozac")
                        .WithMany()
                        .HasForeignKey("VozacId");

                    b.HasOne("TravelEurope.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId");
                });

            modelBuilder.Entity("TravelEurope.Models.TuristRuta", b =>
                {
                    b.HasOne("TravelEurope.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.TuristickiVodic", "TuristickiVodic")
                        .WithMany()
                        .HasForeignKey("TuristickiVodicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Vozac", b =>
                {
                    b.HasOne("TravelEurope.Models.StatusVozaca", "StatusVozaca")
                        .WithMany()
                        .HasForeignKey("StatusVozacaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelEurope.Models.Vozilo", b =>
                {
                    b.HasOne("TravelEurope.Models.MarkaVozila", "MarkaVozila")
                        .WithMany()
                        .HasForeignKey("MarkaVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.StatusVozila", "StatusVozila")
                        .WithMany()
                        .HasForeignKey("StatusVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.TipVozila", "TipVozila")
                        .WithMany()
                        .HasForeignKey("TipVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelEurope.Models.VrstaGoriva", "VrstaGoriva")
                        .WithMany()
                        .HasForeignKey("VrstaGorivaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
