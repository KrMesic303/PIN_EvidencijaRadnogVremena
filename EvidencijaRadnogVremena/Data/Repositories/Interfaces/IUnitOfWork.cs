using EvidencijaRadnogVremena.Models;

namespace EvidencijaRadnogVremena.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Dodati repozitorije
        // IGenericRepository<Actor> Actors {get;}
        //...

        //repositories
        IRepository<AccessPoint> AccessPoints { get; }
        IRepository<Company> Companies { get; }
        IRepository<Person> Persons { get; }
        IRepository<Vehicle> Vehicles { get; }
        IRepository<Visit> Visits { get; }

        Task CompleteAsync();

    }
}
