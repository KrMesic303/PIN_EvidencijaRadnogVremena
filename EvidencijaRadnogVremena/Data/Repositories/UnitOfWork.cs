using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Data.Repository;
using EvidencijaRadnogVremena.Models;
using System.ComponentModel;

namespace EvidencijaRadnogVremena.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        //Initialization of repositories to use commands
        public IRepository<AccessPoint> AccessPoints  {get; private set; }
        public IRepository<Company> Companies  { get; private set; }
        public IRepository<Person> Persons  { get; private set; }
        public IRepository<Vehicle> Vehicles  { get; private set; }
        public IRepository<Visit> Visits { get; private set; }

 
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            //Instantiating repositories with the shared DbContext
            AccessPoints = new Repository<AccessPoint>(_context);
            Companies = new Repository<Company>(_context);
            Persons = new Repository<Person>(_context);
            Vehicles = new Repository<Vehicle>(_context);
            Visits = new Repository<Visit>(_context);

        }


        //Commands
        //Command to execute "Transaction" *all changes made inside repositories are executed;
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