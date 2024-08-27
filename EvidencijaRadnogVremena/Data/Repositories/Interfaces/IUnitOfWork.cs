namespace EvidencijaRadnogVremena.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}
