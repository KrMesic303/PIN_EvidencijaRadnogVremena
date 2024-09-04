using EvidencijaRadnogVremena.Models;
using Microsoft.EntityFrameworkCore;

namespace EvidencijaRadnogVremena.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessPoint>()
                .ToTable("AccessPoints");

            modelBuilder.Entity<Company>()
                .ToTable("Companies");

            modelBuilder.Entity<Person>()
                .ToTable("Persons");

            modelBuilder.Entity<Vehicle>()
                .ToTable("Vehicles");

            modelBuilder.Entity<Visit>()
                .ToTable("Visits");


            base.OnModelCreating(modelBuilder);
        }

    }
}
