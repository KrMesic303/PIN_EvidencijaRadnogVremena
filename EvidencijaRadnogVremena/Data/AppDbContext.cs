using EvidencijaRadnogVremena.Models;
using EvidencijaRadnogVremena.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EvidencijaRadnogVremena.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Person> Visitors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckInOut>().HasOne(c => c.Person).WithMany(p => p.Visits).HasForeignKey(c => c.PersonId);
            modelBuilder.Entity<Vehicle>().HasOne(v => v.Person).WithMany(p => p.Vehicles).HasForeignKey(v => v.PersonId);

            modelBuilder.Entity<Visit>().HasBaseType<CheckInOut>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
