namespace EvidencijaRadnogVremena.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Dodati repozitorije
        // IGenericRepository<Actor> Actors {get;}
        //...

        Task CompleteAsync();



    }
}
