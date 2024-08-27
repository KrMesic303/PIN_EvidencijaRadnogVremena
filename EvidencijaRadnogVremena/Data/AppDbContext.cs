using EvidencijaRadnogVremena.Models;
using Microsoft.EntityFrameworkCore;

namespace EvidencijaRadnogVremena.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
