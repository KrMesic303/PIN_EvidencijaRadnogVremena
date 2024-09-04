using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Data.Repository;
using EvidencijaRadnogVremena.Models;
using System.ComponentModel;

namespace EvidencijaRadnogVremena.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<AccessPoint> AccessPoints  {get; private set; }
        public IRepository<Company> Companies  { get; private set; }
        public IRepository<Person> Persons  { get; private set; }
        public IRepository<Vehicle> Vehicles  { get; private set; }
        public IRepository<Visit> Visits { get; private set; }

 
        public UnitOfWork(IServiceScopeFactory serviceScopeFactory)
        {
            _context = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            AccessPoints = new Repository<AccessPoint>(_context);
            Companies = new Repository<Company>(_context);
            Persons = new Repository<Person>(_context);
            Vehicles = new Repository<Vehicle>(_context);
            Visits = new Repository<Visit>(_context);

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}