using EvidencijaRadnogVremena.Models;

namespace EvidencijaRadnogVremena.Data.Repositories.Interfaces
{
    public interface IAccessPointRepository : IRepository<AccessPoint>
    {
        Task<bool> SetIsActiveStatus(int id, bool isActive);
    }
}
