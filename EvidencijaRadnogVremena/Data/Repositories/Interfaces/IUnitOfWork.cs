using EvidencijaRadnogVremena.Models;

namespace EvidencijaRadnogVremena.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}
