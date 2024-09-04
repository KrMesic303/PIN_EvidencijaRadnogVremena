using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;

namespace EvidencijaRadnogVremena.Data.Repositories
{
    public class AccessPointRepository : Repository.Repository<AccessPoint>, IAccessPointRepository
    {

        public AccessPointRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> SetIsActiveStatus(int id, bool isActive)
        {
            var accessPoint = await GetByIdAsync(id);
            if (accessPoint != null)
            {
                accessPoint.IsActive = isActive;
                
                await _context.SaveChangesAsync();
            }
            
            
            return true;
        }
    }
}
