using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelEurope.Models;

namespace TravelEurope.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<MarkaVozila> MarkaVozila { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<StatusVozaca> StatusVozaca { get; set; }
        public DbSet<TuristickiVodic> TuristickiVodic { get; set; }
        public DbSet<TuristRuta> TuristRuta { get; set; }
        public DbSet<Vozac> Vozac { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<StatusVozila> StatusVozila { get; set; }
        public DbSet<TipVozila> TipVozila { get; set; }
        public DbSet<VrstaGoriva> VrstaGoriva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}